using Microsoft.Extensions.DependencyInjection;

namespace Capgemini.Infra.Configuration.Notifications
{
    public static class NotificationDependency
    {
        public static void AddNotificationPattern(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
        }
    }
}