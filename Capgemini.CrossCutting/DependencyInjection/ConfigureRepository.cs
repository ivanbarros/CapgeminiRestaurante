using Capgemini.Domain.Interfaces.Repositories;
using Capgemini.Domain.UnitOfWork;
using Capgemini.Infra.Repositories;
using Capgemini.Infra.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace Capgemini.CrossCutting.DependencyInjection
{

    public static class ConfigureRepository
    {
        
        public static void ConfigureDependenciesRepositories(this IServiceCollection services)
        {
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IWaiterRepository, WaiterRepository>();
            services.AddScoped<ILogRepository, LogRepository>();

        }
    }
}
