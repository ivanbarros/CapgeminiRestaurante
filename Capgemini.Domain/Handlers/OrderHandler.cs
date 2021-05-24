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
    public class OrderHandler : IRequestHandler<OrderCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IOrderService _service;
        

        public OrderHandler(IMediator mediator, IOrderService service)
        {
            _mediator = mediator;
            _service = service;
           
        }

        public async Task<string> Handle(OrderCommand request, CancellationToken cancellationToken)
        {
            
            var pedido = new OrderDTO
            {
                TableNumber = request.Orders.TableNumber,
                SteakDone = request.Orders.SteakDone.ToString(),
                IdWaiter = request.Orders.IdWaiter ,
                Name = request.Orders.Food.Name,
                Quantity = request.Orders.Quantity

            };
            
            try
            {
                await _service.AddOrders(pedido);

                return await Task.FromResult("Pedido criado com sucesso");
            }
            catch (Exception ex)
            {

                await _mediator.Publish(new OrderNotification {TableNumber = pedido.TableNumber, SteakDone = pedido.SteakDone.ToString() });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }
        }
    }
}
