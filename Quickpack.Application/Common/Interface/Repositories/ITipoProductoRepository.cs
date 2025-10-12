using Quickpack.Application.TipoProducto.Command.AgregarTipoProducto;
using Quickpack.Application.TipoProducto.Command.EditarEstadoTipoProducto;
using Quickpack.Application.TipoProducto.Command.EditarTipoProducto;
using Quickpack.Application.TipoProducto.Query.ObtenerTipoProducto;
using Quickpack.Application.TipoProducto.Query.ObtenerTipoProductoMenu;
using Quickpack.Application.TipoProducto.Query.VerTipoProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Common.Interface.Repositories
{
    public interface ITipoProductoRepository
    {
        Task<AgregarTipoProductoCommandDTO> AgregarTipoProducto(AgregarTipoProductoCommand command);
        Task<ObtenerTipoProductoQueryDTO> ObtenerTipoProducto(ObtenerTipoProductoQuery query);
        Task<VerTipoProductoQueryDTO> VerTipoProducto(VerTipoProductoQuery query);
        Task<EditarTipoProductoCommandDTO> EditarTipoProducto(EditarTipoProductoCommand command);
        Task<EditarEstadoTipoProductoCommandDTO> EditarEstadoTipoProducto(EditarEstadoTipoProductoCommand command);
        Task<IEnumerable<ObtenerTipoProductoMenuQueryDTO>> ObtenerTipoProductoMenu(ObtenerTipoProductoMenuQuery query);
    }
}
