using MediatR;

namespace Capgemini.Domain.Notifications
{
    public class FoodCriadaNotification : INotification
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string Taste { get; set; }
        public string Temperature { get; set; }
    }
}
