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

namespace Quickpack.Application.Common.Interface.Repositories
{
    public interface ICategoriaRepository
    {
        Task<AgregarCategoriaCommandDTO> AgregarCategoria(AgregarCategoriaCommand command);
        Task<ObtenerCategoriaQueryDTO> ObtenerCategoria(ObtenerCategoriaQuery query);
        Task<EditarEstadoCategoriaCommandDTO> EditarEstadoCategoria(EditarEstadoCategoriaCommand command);
        Task<EditarCategoriaCommandDTO> EditarCategoria(EditarCategoriaCommand command);
        Task<VerCategoriaQueryDTO> VerCategoria(VerCategoriaQuery query);
        Task<IEnumerable<ObtenerCategoriaMenuQueryDTO>> ObtenerCategoriaMenu(ObtenerCategoriaMenuQuery query);
        Task<AgregarBeneficiosCommandDTO> AgregarBeneficio(AgregarBeneficiosCommand command);
        Task<ObtenerBeneficioQueryDTO> ObtenerBeneficio(ObtenerBeneficioQuery query);
        Task<AgregarCaracteristicaCommandDTO> AgregarCaracteristica(AgregarCaracteristicaCommand query);
        Task<IEnumerable<ObtenerCaracteristicaQueryDTO>> ObtenerCaracteristica(ObtenerCaracteristicaQuery query);
        Task<VerCaracteristicaQueryDTO> VerCaracteristica(VerCaracteristicaQuery query);
        Task<EliminarCaracteristicaCommandDTO> EliminarCaracteristica(EliminarCaracteristicaCommand query);
    }
}
