﻿using Capgemini.Domain.Commands;
using Capgemini.Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace Capgemini.Apresentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WaiterController : ControllerBase
    {
        private readonly IWaiterService _service;
        private readonly ILogService _logService;
        private readonly IMediator _mediator;

        public WaiterController(IWaiterService order, ILogService logService, IMediator mediator)
        {
            _service = order;
            _logService = logService;
            _mediator = mediator;
        }

        [HttpGet("AllWaiters")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
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
                var result = await _service.GetAllWaiters();
                return Ok(result);
            }
            catch (Exception ex)
            {
               

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);


            }
        }


        [HttpPost]
        [Route("Order")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerOperation(
           Summary = "inserção de  pedidos realizados no dia"
       )]
        public async Task<IActionResult> InsertOrder([FromBody, Required] WaiterCommand waiter)
        {

            var response = await _mediator.Send(waiter);
            return Ok(response);
        }
    }
}
