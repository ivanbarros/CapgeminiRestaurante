using AutoMapper;
using Capgemini.Apresentation.Filter;
using Capgemini.CrossCutting.Config;
using Capgemini.CrossCutting.DependencyInjection;
using Capgemini.CrossCutting.Mappings;
using Capgemini.CrossCutting.MySqlConfig;
using Capgemini.Infra.Configuration.Notifications;
using Capgemini.Infra.Configuration.Swagger;
using Capgemini.Infra.Migrations.MigrationsConfig;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;

namespace Capgemini.Apresentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => {
                cfg.AddProfile(new EntityToDtoProfile());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            MigratorServices.CreateService(Configuration["sqlDb:connectionString"]);
            //MigratorServices.CreateMysqlService(Configuration["MysqlDb:connectionString"]);
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepositories(services);

            services.AddMvc(opt => opt.Filters.Add<NotificationFilter>())
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            //services.AddMySqlDatabase(Configuration);
            services.AddSqlDatabase(Configuration);
            services.AddNotificationPattern();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfiguration = new TokenConfigurations();

            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations")).Configure(tokenConfiguration);
            services.AddSingleton(tokenConfiguration);
            services.AddSwaggerFramework(Environment, Configuration);
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.SecurityKey;
                paramsValidation.ValidAudience = tokenConfiguration.Audience;
                paramsValidation.ValidIssuer = tokenConfiguration.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser().Build());
            });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Ativando middlewares para uso do Swagger
            app.UseSwaggerFramework();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
