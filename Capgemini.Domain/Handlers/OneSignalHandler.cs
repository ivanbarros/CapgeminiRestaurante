using Capgemini.Domain.Commands;
using Capgemini.Domain.Interfaces.Services;
using Capgemini.Domain.Models;
using Capgemini.Domain.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Capgemini.Domain.Handlers
{
    public class OneSignalHandler : IRequestHandler<OneSignalCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IOneSignalService _service;
        private readonly ILogService _logService;

        public OneSignalHandler(IMediator mediator, IOneSignalService service, ILogService logService)
        {
            _mediator = mediator;
            _service = service;
            _logService = logService;
        }

        public async Task<string> Handle(OneSignalCommand request, CancellationToken cancellationToken)
        {
            var signal = new CreateNotificationModel() 
            {
                Title = request.Title,
                Content = request.Content,
                LinkUrl = request.LinkUrl,
                PlayersId = request.PlayersId,
                TemplateName = request.TemplateName,
                Segments = request.Segments
            };
            try
            {
                var sendOneSignal = _service.PostOneSignal(signal);
                await _mediator.Publish(new OneSignalCriadoNotification() 
                {
                    Title = request.Title,
                    Content = request.Content,
                    LinkUrl = request.LinkUrl,
                    PlayersId = request.PlayersId,
                    TemplateName = request.TemplateName,
                    Segments = request.Segments
                });
                 return await Task.FromResult($"{sendOneSignal} enviado com sucesso");
            }
            catch (Exception ex)
            {

                return await Task.FromResult($"Falha ao enviar ao onesignal devido ao erro : {ex.Message}");
            }
        }
    }
}
