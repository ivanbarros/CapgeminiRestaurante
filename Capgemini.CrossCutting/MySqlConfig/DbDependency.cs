using Capgemini.CrossCutting.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Capgemini.CrossCutting.MySqlConfig
{
    public static class DbDependency
    {
        public static void AddMySqlDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMySqlConfiguration(configuration);
            services.ConfigureDependenciesRepositories();
        }

        public static void AddSqlDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlConfiguration(configuration);
            services.ConfigureDependenciesRepositories();
        }
    }
}
