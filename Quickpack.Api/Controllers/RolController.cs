using Microsoft.AspNetCore.Mvc;
using Quickpack.Api.Filter;
using Quickpack.Application.Autenticacion.command.IniciarSesion;
using Quickpack.Application.Autenticacion.command.ObtenerMenu;
using Quickpack.Application.Rol.Command;
using Quickpack.Application.Rol.Query.ObtenerRol;

namespace Quickpack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class RolController : AbstractController
    {
        [HttpGet]
        [Route("obtenerRoles")]
        [ProducesResponseType(typeof(ObtenerRolQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerRol(ObtenerRolQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [Route("agregarRoles")]
        [ProducesResponseType(typeof(AgregarRolCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgregarRol(AgregarRolCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
