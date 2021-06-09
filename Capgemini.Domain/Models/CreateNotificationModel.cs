using System.Collections.Generic;

namespace Capgemini.Domain.Models
{
    public class CreateNotificationModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string TemplateName { get; set; }
        public string TemplateId { get; set; }
        public List<string> PlayersId { get; set; }
        public string LinkUrl { get; set; }
        public List<string> Segments { get; set; }
    }
}
