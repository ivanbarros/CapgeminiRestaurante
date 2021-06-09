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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capgemini.Apresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneSignalController : ControllerBase
    {
        
        
        
        private readonly IMediator _mediator;
        public OneSignalController(IMediator mediator)
        {

            _mediator = mediator;
        }

        ///
        [ActionName(nameof(PostOneSignal))]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        // POST api/<OneSignalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OneSignalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OneSignalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
