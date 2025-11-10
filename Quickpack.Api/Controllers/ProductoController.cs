using Microsoft.AspNetCore.Mvc;
using Quickpack.Api.Filter;
using Quickpack.Application.Producto.Command.AgregarFichaTecnica;
using Quickpack.Application.Producto.Command.AgregarProducto;
using Quickpack.Application.Producto.Command.EditarEstadoProducto;
using Quickpack.Application.Producto.Command.EditarFichaTecnica;
using Quickpack.Application.Producto.Command.EditarProducto;
using Quickpack.Application.Producto.Query.ObtenerProducto;
using Quickpack.Application.Producto.Query.VerFichaTecnica;
using Quickpack.Application.Producto.Query.VerProducto;

namespace Quickpack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilter))]
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

        [HttpPost]
        [Route("agregarFichaTecnica")]
        [ProducesResponseType(typeof(AgregarFichaTecnicaCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgregarFichaTecnica(AgregarFichaTecnicaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("verFichaTecnica/{idProducto}")]
        [ProducesResponseType(typeof(VerFichaTecnicaQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> VerFichaTecnica(int idProducto)
        {
            var response = await Mediator.Send(
                    new VerFichaTecnicaQuery()
                    {
                        IdProducto = idProducto
                    }
                );
            return Ok(response);
        }

        [HttpPut]
        [Route("editarFichaTecnica")]
        [ProducesResponseType(typeof(EditarFichaTecnicaCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarFichaTecnica(EditarFichaTecnicaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
