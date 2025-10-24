using Quickpack.Application.Producto.Command.AgregarFichaTecnica;
using Quickpack.Application.Producto.Command.AgregarProducto;
using Quickpack.Application.Producto.Command.EditarEstadoProducto;
using Quickpack.Application.Producto.Command.EditarFichaTecnica;
using Quickpack.Application.Producto.Command.EditarProducto;
using Quickpack.Application.Producto.Query.ObtenerProducto;
using Quickpack.Application.Producto.Query.VerFichaTecnica;
using Quickpack.Application.Producto.Query.VerProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Common.Interface.Repositories
{
    public interface IProductoRepository
    {
        Task<AgregarProductoCommandDTO> AgregarProducto(AgregarProductoCommand command);
        Task<ObtenerProductoQueryDTO> ObtenerProducto(ObtenerProductoQuery query);
        Task<EditarEstadoProductoCommandDTO> EditarEstadoProducto(EditarEstadoProductoCommand command);
        Task<VerProductoQueryDTO> VerProducto(VerProductoQuery query);
        Task<EditarProductoCommandDTO> EditarProducto(EditarProductoCommand command);
        Task<AgregarFichaTecnicaCommandDTO> AgregarFichaTecnica(AgregarFichaTecnicaCommand command);
        Task<EditarFichaTecnicaCommandDTO> EditarFichaTecnica(EditarFichaTecnicaCommand command);
        Task<VerFichaTecnicaQueryDTO> VerFichaTecnica(VerFichaTecnicaQuery query);
    }
}
