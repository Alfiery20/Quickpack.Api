using Microsoft.AspNetCore.Mvc;
using Quickpack.Api.Filter;
using Quickpack.Application.Empleado.Command.AgregarEmpleado;
using Quickpack.Application.Empleado.Command.EditarEmpleado;
using Quickpack.Application.Empleado.Command.EditarEstadoEmpleado;
using Quickpack.Application.Empleado.Query.ObtenerEmpleado;
using Quickpack.Application.Empleado.Query.VerEmpleado;
using Quickpack.Application.Rol.Command.AgregarRol;
using Quickpack.Application.Rol.Query.ObtenerRol;
using Quickpack.Application.Rol.Query.VerRol;

namespace Quickpack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class EmpleadoController : AbstractController
    {
        [HttpPost]
        [Route("obtenerEmpleado")]
        [ProducesResponseType(typeof(ObtenerEmpleadoQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerEmpleado(ObtenerEmpleadoQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [Route("agregarEmpleado")]
        [ProducesResponseType(typeof(AgregarEmpleadoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgregarEmpleado(AgregarEmpleadoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("editarEstadoEmpleado/{idEmpleado}")]
        [ProducesResponseType(typeof(EditarEstadoEmpleadoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarEstadoEmpleado(int idEmpleado)
        {
            var response = await Mediator.Send(
                    new EditarEstadoEmpleadoCommand()
                    {
                        IdEmpleado = idEmpleado
                    }
                );
            return Ok(response);
        }

        [HttpGet]
        [Route("verEmpleado/{idEmpleado}")]
        [ProducesResponseType(typeof(VerEmpleadoQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> VerEmpleado(int idEmpleado)
        {
            var response = await Mediator.Send(
                    new VerEmpleadoQuery()
                    {
                        IdEmpleado = idEmpleado
                    }
                );
            return Ok(response);
        }

        [HttpPut]
        [Route("editarEmpleado")]
        [ProducesResponseType(typeof(EditarEmpleadoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarEmpleado(EditarEmpleadoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
