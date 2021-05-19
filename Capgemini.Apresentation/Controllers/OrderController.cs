using Capgemini.Domain.Commands;
using Capgemini.Domain.Entities;
using Capgemini.Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Capgemini.Apresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;
        private readonly ILogService _logService;
        private readonly IMediator _mediator;
        

        public OrderController(IOrderService order, ILogService logService,
            IMediator mediator)
        {
            _order = order;
            _logService = logService;
            _mediator = mediator;
           

        }

        [HttpGet("OrderById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerOperation(
            Summary = "Visualização dos pedidos realizados no dia pelo Id"
        )]
        public async Task<IActionResult> GetOrderById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await _order.GetOrderById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
              

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("AllOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerOperation(
            Summary = "Visualização de todos pedidos realizados"
        )]
        public async Task<IActionResult> GetAllOrder()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var result = await _order.GetAllOrder();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

                
            }
        }

        [HttpGet("GetOrderByTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerOperation(
            Summary = "Visualização de todos pedidos realizados de determinada mesa"
        )]
        public async Task<IActionResult> GetOrderByTable(int table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _order.GetOrderByTable(table);
            return Ok(result);
        }

        [HttpPost]
        [Route("Order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerOperation(
           Summary = "inserção de  pedidos realizados no dia"
       )]
        public async Task<IActionResult> InsertOrder([FromBody, Required] OrderCommand order)
        {
            
            var response = await _mediator.Send(order);
            return Ok(response);
        }
    }
}