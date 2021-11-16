using Flunt.Validations;
using MediatR;
using System;
using System.Collections.Generic;

namespace Capgemini.Domain.Commands
{
    public class OneSignalCommand : IRequest<string>
    {
        public OneSignalCommand(
            string title,
            string content,
            string templateName, 
            List<string> playersId,
            string linkUrl,
            List<string> segments)
        {
            Title = title;
            Content = content;
            TemplateName = templateName;
            PlayersId = playersId;
            LinkUrl = linkUrl;
            Segments = segments;
            Validate();
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string TemplateName { get; set; }
        public List<string> PlayersId { get; set; }
        public string LinkUrl { get; set; }
        public List<string> Segments { get; set; }

        public  void Validate()
        {
            var flunt = new Contract<OneSignalCommand>();

            flunt.Requires()
                
                .IsNotNullOrWhiteSpace(Title, "Title", "Favor informar Title.")
                .IsNotNullOrWhiteSpace(Content, "Content", "Favor informar Content.");

            if (!flunt.IsValid)
                flunt.AddNotifications(flunt.Notifications);
        }
    }
}
