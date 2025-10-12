using Quickpack.Application.Categoria.Command.AgregarBeneficios;
using Quickpack.Application.Categoria.Command.AgregarCategoria;
using Quickpack.Application.Categoria.Command.CambiarEstadoCategoria;
using Quickpack.Application.Categoria.Command.EditarCategoria;
using Quickpack.Application.Categoria.Query.ObtenerCategoria;
using Quickpack.Application.Categoria.Query.ObtenerCategoriaMenu;
using Quickpack.Application.Categoria.Query.VerCategoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
