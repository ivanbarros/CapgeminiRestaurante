using Capgemini.CrossCutting.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Capgemini.CrossCutting.MySqlConfig
{
    public static class MySqlDependency
    {
        public static void AddMySqlDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMySqlConfiguration(configuration);
            services.ConfigureDependenciesRepositories();
        }
    }
}
