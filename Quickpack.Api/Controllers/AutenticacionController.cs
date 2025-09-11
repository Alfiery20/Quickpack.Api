using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quickpack.Application.Autenticacion.command.IniciarSesion;

namespace Quickpack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AutenticacionController : AbstractController
    {
        [HttpPost]
        [Route("iniciarSesion")]
        [ProducesResponseType(typeof(IniciarSesionCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> IniciarSesion(IniciarSesionCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
