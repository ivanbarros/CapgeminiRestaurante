using Capgemini.Domain.Interfaces.Services;
using Capgemini.Domain.UnitOfWork;
using Capgemini.Infra.Services;
using Capgemini.Infra.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace Capgemini.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(this IServiceCollection services)
        {
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWaiterService, WaiterService>();
            services.AddScoped<IOneSignalService, OneSignalService>();
        }
    }
}
