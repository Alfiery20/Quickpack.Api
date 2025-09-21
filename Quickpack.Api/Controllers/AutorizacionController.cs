using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quickpack.Api.Filter;
using Quickpack.Application.Autenticacion.command.IniciarSesion;
using Quickpack.Application.Autenticacion.command.ObtenerMenu;

namespace Quickpack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class AutorizacionController : AbstractController
    {
        [HttpPost]
        [Route("obtenerMenu")]
        [ProducesResponseType(typeof(IniciarSesionCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerMenu(ObtenerMenuCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
