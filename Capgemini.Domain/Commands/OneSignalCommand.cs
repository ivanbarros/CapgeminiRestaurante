using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.Domain.Commands
{
    public class OneSignalCommand : IRequest<string>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string TemplateName { get; set; }
        public List<string> PlayersId { get; set; }
        public string LinkUrl { get; set; }
        public List<string> Segments { get; set; }
    }
}
