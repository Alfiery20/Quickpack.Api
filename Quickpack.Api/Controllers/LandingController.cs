using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}
