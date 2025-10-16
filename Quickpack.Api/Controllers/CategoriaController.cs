using Microsoft.AspNetCore.Mvc;
using Quickpack.Api.Filter;
using Quickpack.Application.Categoria.Command.AgregarBeneficios;
using Quickpack.Application.Categoria.Command.AgregarCaracteristica;
using Quickpack.Application.Categoria.Command.AgregarCategoria;
using Quickpack.Application.Categoria.Command.CambiarEstadoCategoria;
using Quickpack.Application.Categoria.Command.EditarCategoria;
using Quickpack.Application.Categoria.Command.EliminarCaracteristica;
using Quickpack.Application.Categoria.Query.ObtenerBeneficio;
using Quickpack.Application.Categoria.Query.ObtenerCaracteristica;
using Quickpack.Application.Categoria.Query.ObtenerCategoria;
using Quickpack.Application.Categoria.Query.ObtenerCategoriaMenu;
using Quickpack.Application.Categoria.Query.VerCaracteristica;
using Quickpack.Application.Categoria.Query.VerCategoria;

namespace Quickpack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizationFilter]
    public class CategoriaController : AbstractController
    {
        [HttpPost]
        [Route("obtenerCategoria")]
        [ProducesResponseType(typeof(ObtenerCategoriaQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerCategoria(ObtenerCategoriaQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [Route("agregarCategoria")]
        [ProducesResponseType(typeof(AgregarCategoriaCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgregarCategoria(AgregarCategoriaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("verCategoria/{idCategoria}")]
        [ProducesResponseType(typeof(VerCategoriaQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> VerCategoria(int idCategoria)
        {
            var response = await Mediator.Send(
                    new VerCategoriaQuery()
                    {
                        IdCategoria = idCategoria
                    }
                );
            return Ok(response);
        }

        [HttpPut]
        [Route("editarCategoria")]
        [ProducesResponseType(typeof(EditarCategoriaCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarCategoria(EditarCategoriaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("editarEstadoCategoria/{idCategoria}")]
        [ProducesResponseType(typeof(EditarEstadoCategoriaCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarEstadoCategoria(int idCategoria)
        {
            var response = await Mediator.Send(new EditarEstadoCategoriaCommand()
            {
                IdCategoria = idCategoria
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerCategoriaMenu")]
        [ProducesResponseType(typeof(ObtenerCategoriaQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerCategoriaMenu()
        {
            var response = await Mediator.Send(new ObtenerCategoriaMenuQuery());
            return Ok(response);
        }

        [HttpPost]
        [Route("agregarBeneficio")]
        [ProducesResponseType(typeof(AgregarBeneficiosCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgregarBeneficio(AgregarBeneficiosCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerBeneficio/{idCategoria}")]
        [ProducesResponseType(typeof(ObtenerBeneficioQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerBeneficio(int idCategoria)
        {
            var response = await Mediator.Send(new ObtenerBeneficioQuery()
            {
                IdCategoria = idCategoria
            });
            return Ok(response);
        }

        [HttpPost]
        [Route("agregarCaracteristica")]
        [ProducesResponseType(typeof(AgregarCaracteristicaCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgregarCaracteristica(AgregarCaracteristicaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerCaracteristica/{idCategoria}")]
        [ProducesResponseType(typeof(ObtenerCaracteristicaQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerCaracteristica(int idCategoria)
        {
            var response = await Mediator.Send(new ObtenerCaracteristicaQuery()
            {
                IdCategoria = idCategoria
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("verCaracteristica/{idCaracteristica}")]
        [ProducesResponseType(typeof(VerCaracteristicaQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> VerCaracteristica(int idCaracteristica)
        {
            var response = await Mediator.Send(new VerCaracteristicaQuery()
            {
                IdCaracteristica = idCaracteristica
            });
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminarCaracteristica/{idCaracteristica}")]
        [ProducesResponseType(typeof(EliminarCaracteristicaCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EliminarCaracteristica(int idCaracteristica)
        {
            var response = await Mediator.Send(new EliminarCaracteristicaCommand()
            {
                IdCaracteristica = idCaracteristica
            });
            return Ok(response);
        }
    }
}
