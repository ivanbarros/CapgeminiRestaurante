using Capgemini.Domain.Commands;
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
    public class FoodController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        private readonly IFoodService _service;

        public FoodController(IMediator mediator,
            IFoodService service)
        {
            
            _mediator = mediator;
            _service = service;

        }

        [HttpGet("FoodById")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerOperation(
            Summary = "Visualização dos alimentos pelo Id"
        )]

        
        public async Task<IActionResult> GetFoodById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await _service.GetFoodById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
              

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("InsertFood")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerOperation(
            Summary = "Inserção dos alimentos"
        )]
        public async Task<IActionResult> InsertFood([FromBody, Required] FoodCommand food)
        {
            try
            {
                var response = await _mediator.Send(food);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}