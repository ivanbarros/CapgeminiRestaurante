using Flunt.Notifications;

namespace Capgemini.Infra.Configuration.Notifications
{
    public class NotificationContext: Notifiable<Notification>
    {
        public NotificationContext() =>
            HandleConflict = true;

        public bool HandleConflict { get; set; }
    }
}
