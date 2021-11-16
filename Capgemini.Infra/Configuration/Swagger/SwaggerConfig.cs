﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace Capgemini.Infra.Configuration.Swagger
{
    public static class SwaggerConfig
    {

        public static void AddSwaggerFramework(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration Configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AspnetCore 3.1",
                    Description = "API REST criada com o Asp.Net core e arquitetura DDD",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Ivan Barros",
                        Email = "ivansilvabarros@outlook.com",
                        Url = new Uri("https://www.linkedin.com/in/ivbarros/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "GitHub",
                        Url = new Uri("https://github.com/ivanbarros/"),
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Entre com o token JWT",
                    Name = "authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            }, new List<string>()
        }
    });

            });

            services.AddControllers().AddNewtonsoftJson();
        }

        public static void UseSwaggerFramework(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurante Capgemini");
            });
        }

    }
}
