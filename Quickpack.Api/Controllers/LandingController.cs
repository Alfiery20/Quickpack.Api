using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quickpack.Application.Landing.Command.EnviarConsulta;
using Quickpack.Application.Landing.Query.ObtenerCategoriaLanding;
using Quickpack.Application.Landing.Query.ObtenerTipoProductoLanding;
using Quickpack.Application.TipoProducto.Query.ObtenerTipoProducto;
using Quickpack.Application.TipoProducto.Query.ObtenerTipoProductoMenu;

namespace Quickpack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LandingController : AbstractController
    {
        [HttpGet]
        [Route("obtenerTipoProductoMenuLanding")]
        [ProducesResponseType(typeof(ObtenerTipoProductoMenuQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTipoProductoMenu()
        {
            var response = await Mediator.Send(new ObtenerTipoProductoMenuQuery());
            return Ok(response);
        }

        [HttpPost]
        [Route("enviarCorreoConsulta")]
        [ProducesResponseType(typeof(EnviarConsultaCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EnviarCorreoConsulta(EnviarConsultaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerTipoProductoLanding/{id}")]
        [ProducesResponseType(typeof(ObtenerTipoProductoLandingQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTipoProductoLanding(int id)
        {
            var response = await Mediator.Send(
                new ObtenerTipoProductoLandingQuery()
                {
                    IdTipoProducto = id
                }
                );
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerTipoProductoLanding/{idTipoProducto}/categoria/{idCategoria}")]
        [ProducesResponseType(typeof(ObtenerCategoriaLandingQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerCategoriaLanding(int idTipoProducto, int idCategoria)
        {
            var response = await Mediator.Send(
                new ObtenerCategoriaLandingQuery()
                {
                    IdTipoProducto = idTipoProducto,
                    IdCategoria = idCategoria
                }
                );
            return Ok(response);
        }
    }
}
