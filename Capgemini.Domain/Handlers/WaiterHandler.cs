using Capgemini.Domain.Commands;
using Capgemini.Domain.DTOs;
using Capgemini.Domain.Interfaces.Services;
using Capgemini.Domain.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Capgemini.Domain.Handlers
{
    public class WaiterHandler : IRequestHandler<WaiterCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IWaiterService _service;

        public WaiterHandler(IMediator mediator, IWaiterService service)
        {
            _mediator = mediator;
            _service = service;
        }

        public async Task<string> Handle(WaiterCommand request, CancellationToken cancellationToken)
        {
            var waiter = new WaiterDTO
            {
                Name = request.Name
            };
        
            try
            {
                await _service.AddWaiters(waiter);


        await _mediator.Publish(new WaiterCriadoNotification {
                    Name = request.Name,
    });

                return await Task.FromResult("Garçom criado com sucesso");
}
            catch (Exception ex)
{
    await _mediator.Publish(new FoodCriadaNotification
    {
        Name = request.Name,
       
    });
    await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
    return await Task.FromResult("Ocorreu um erro no momento da criação");
}
        }
    }
}