using Microsoft.AspNetCore.Mvc;
using Quickpack.Api.Filter;
using Quickpack.Application.Rol.Command.AgregarRol;
using Quickpack.Application.Rol.Command.EditarEstadoRol;
using Quickpack.Application.Rol.Command.EditarRol;
using Quickpack.Application.Rol.Query.ObtenerRol;
using Quickpack.Application.Rol.Query.VerRol;
using Quickpack.Application.TipoProducto.Command.AgregarTipoProducto;
using Quickpack.Application.TipoProducto.Command.EditarEstadoTipoProducto;
using Quickpack.Application.TipoProducto.Command.EditarTipoProducto;
using Quickpack.Application.TipoProducto.Query.ObtenerTipoProducto;
using Quickpack.Application.TipoProducto.Query.ObtenerTipoProductoMenu;
using Quickpack.Application.TipoProducto.Query.VerTipoProducto;

namespace Quickpack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class TipoProductoController : AbstractController
    {
        [HttpPost]
        [Route("obtenerTipoProducto")]
        [ProducesResponseType(typeof(ObtenerTipoProductoQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTipoProducto(ObtenerTipoProductoQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [Route("agregarTipoProducto")]
        [ProducesResponseType(typeof(AgregarTipoProductoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgregarTipoProducto(AgregarTipoProductoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("verTipoProducto/{idTipoProducto}")]
        [ProducesResponseType(typeof(VerTipoProductoQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> VerTipoProducto(int idTipoProducto)
        {
            var response = await Mediator.Send(
                    new VerTipoProductoQuery()
                    {
                        IdTipoProducto = idTipoProducto
                    }
                );
            return Ok(response);
        }

        [HttpPut]
        [Route("editarTipoProducto")]
        [ProducesResponseType(typeof(EditarTipoProductoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarTipoProducto(EditarTipoProductoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("editarEstadoTipoProducto/{idTipoProducto}")]
        [ProducesResponseType(typeof(EditarEstadoTipoProductoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarEstadoTipoProducto(int idTipoProducto)
        {
            var response = await Mediator.Send(new EditarEstadoTipoProductoCommand()
            {
                IdTipoProducto = idTipoProducto
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerTipoProductoMenu")]
        [ProducesResponseType(typeof(ObtenerTipoProductoQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTipoProductoMenu()
        {
            var response = await Mediator.Send(new ObtenerTipoProductoMenuQuery());
            return Ok(response);
        }
    }
}
