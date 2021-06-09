using System.Collections.Generic;

namespace Capgemini.Domain.Notifications
{
    public class OneSignalCriadoNotification
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string TemplateName { get; set; }
        public List<string> PlayersId { get; set; }
        public string LinkUrl { get; set; }
        public List<string> Segments { get; set; }
    }
}
