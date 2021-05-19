using Capgemini.Domain.Commands;
using Capgemini.Domain.DTOs;
using Capgemini.Domain.Interfaces.Services;
using Capgemini.Domain.Notifications;
using MediatR;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Capgemini.Domain.Handlers
{
    public class FoodHandler : IRequestHandler<FoodCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IFoodService _service;
        private readonly ILogService _logService;
        public FoodHandler(ILogService logService, IMediator mediator, IFoodService service)
        {
            _logService = logService;
            _mediator = mediator;
            _service = service;
        }

        public async Task<string> Handle(FoodCommand request, CancellationToken cancellationToken)
        {
            
            var foods = new FoodDTO
            { 
                Name = request.Name,
                Price = request.Price,
                Taste = request.Taste.ToString(),
                Temperature = request.Temperature.ToString(),
                Type = request.Type.ToString()
            };

            try
            {

                
                foods = await _service.AddFoods(foods);
               

                await _mediator.Publish(new FoodCriadaNotification {
                    Name = request.Name,
                    Price = request.Price,
                    Taste = request.Taste.ToString(),
                    Temperature = request.Temperature.ToString(),
                    Type = request.Type.ToString()
                });
                
                return await Task.FromResult("Alimento criado com sucesso");

            }
            catch (Exception ex)
            {
                await _mediator.Publish(new FoodCriadaNotification {
                    Name = request.Name,
                    Price = request.Price,
                    Taste = request.Taste.ToString(),
                    Temperature = request.Temperature.ToString(),
                    Type = request.Type.ToString()
                });
                var _log = new LogDTO();
                var _stackTrace = new StackTrace();
                
                _log.Method_Name = _stackTrace.GetFrame(3).GetMethod().Name;
                _log.ErrorDay = DateTime.UtcNow;
                _log.ErrorMessage = ex.Message.ToString().Replace("'", " ");
                await _logService.AddLog(_log);

                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }
        }
    }
}
