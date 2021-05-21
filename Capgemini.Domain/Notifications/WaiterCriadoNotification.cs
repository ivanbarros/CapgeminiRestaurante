using MediatR;

namespace Capgemini.Domain.Notifications
{
    public class WaiterCriadoNotification : INotification
    {
        public string Name { get; set; }
    }
}
