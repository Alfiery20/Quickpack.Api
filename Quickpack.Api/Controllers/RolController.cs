using Microsoft.AspNetCore.Mvc;
using Quickpack.Api.Filter;
using Quickpack.Application.Autenticacion.command.IniciarSesion;
using Quickpack.Application.Autenticacion.command.ObtenerMenu;
using Quickpack.Application.Rol.Command.AgregarRol;
using Quickpack.Application.Rol.Command.EditarEstadoRol;
using Quickpack.Application.Rol.Command.EditarRol;
using Quickpack.Application.Rol.Query.ObtenerPermisoRol;
using Quickpack.Application.Rol.Query.ObtenerRol;
using Quickpack.Application.Rol.Query.VerRol;

namespace Quickpack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class RolController : AbstractController
    {
        [HttpPost]
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

        [HttpGet]
        [Route("verRol/{idRol}")]
        [ProducesResponseType(typeof(ObtenerRolQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> VerRol(int idRol)
        {
            var response = await Mediator.Send(
                    new VerRolQuery()
                    {
                        IdRol = idRol
                    }
                );
            return Ok(response);
        }

        [HttpPut]
        [Route("editarRol")]
        [ProducesResponseType(typeof(EditarRolCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarRol(EditarRolCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("editarEstadoRol/{idRol}")]
        [ProducesResponseType(typeof(EditarEstadoRolCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarEstadoRol(int idRol)
        {
            var response = await Mediator.Send(new EditarEstadoRolCommand()
            {
                IdRol = idRol
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerPermisoRol/{idRol}")]
        [ProducesResponseType(typeof(ObtenerPermisoRolQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerPermisoRol(int idRol)
        {
            var response = await Mediator.Send(new ObtenerPermisoRolQuery()
            {
                IdRol = idRol
            });
            return Ok(response);
        }
    }
}
