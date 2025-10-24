using Microsoft.AspNetCore.Mvc;
using Quickpack.Api.Filter;
using Quickpack.Application.Producto.Command.AgregarProducto;
using Quickpack.Application.Producto.Command.EditarEstadoProducto;
using Quickpack.Application.Producto.Command.EditarProducto;
using Quickpack.Application.Producto.Query.ObtenerProducto;
using Quickpack.Application.Producto.Query.VerProducto;

namespace Quickpack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class ProductoController : AbstractController
    {
        [HttpPost]
        [Route("obtenerProducto")]
        [ProducesResponseType(typeof(ObtenerProductoQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerProducto(ObtenerProductoQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [Route("agregarProducto")]
        [ProducesResponseType(typeof(AgregarProductoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgregarProducto(AgregarProductoCommand command)
        {
            command.IdUsuario = Convert.ToInt32(this.CurrentUser.Id);
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("verProducto/{idProducto}")]
        [ProducesResponseType(typeof(VerProductoQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> VerProducto(int idProducto)
        {
            var response = await Mediator.Send(
                    new VerProductoQuery()
                    {
                        IdProducto = idProducto
                    }
                );
            return Ok(response);
        }

        [HttpPut]
        [Route("editarProducto")]
        [ProducesResponseType(typeof(EditarProductoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarProducto(EditarProductoCommand command)
        {
            command.IdUsuario = Convert.ToInt32(this.CurrentUser.Id);
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("editarEstadoProducto/{idProducto}")]
        [ProducesResponseType(typeof(EditarEstadoProductoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarEstadoProducto(int idProducto)
        {
            var response = await Mediator.Send(new EditarEstadoProductoCommand()
            {
                IdProducto = idProducto
            });
            return Ok(response);
        }
    }
}
