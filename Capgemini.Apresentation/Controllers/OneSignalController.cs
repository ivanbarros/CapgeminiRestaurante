using Capgemini.Domain.Commands;
using Capgemini.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;


namespace Capgemini.Apresentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OneSignalController : ControllerBase
    {



        private readonly IMediator _mediator;
        public OneSignalController(IMediator mediator)
        {

            _mediator = mediator;
        }

        
        [ActionName(nameof(PostOneSignal))]
        [HttpPost()]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostOneSignal([FromBody, Required, SwaggerParameter("Endpoint para acessar o Onesignal ")] OneSignalCommand OneSignal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {

                var result = await _mediator.Send(OneSignal);

                return Ok(result);
            }
            catch (Exception ex)
            {
                StackTrace _trace = new StackTrace();
                var name = _trace.GetFrame(1);
                LogEntity logs = new LogEntity()
                {
                    ControllerName = ControllerContext.ActionDescriptor.ControllerName,
                    MethodName = MethodBase.GetCurrentMethod().Name + " " + name.GetMethod().Name,
                    ErrorMessage = ex.Message,
                    ErrorDay = DateTime.UtcNow
                };

                return BadRequest();
            }
        }
    }
}
