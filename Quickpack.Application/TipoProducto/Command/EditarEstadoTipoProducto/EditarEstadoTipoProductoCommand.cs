using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.TipoProducto.Command.EditarEstadoTipoProducto
{
    public class EditarEstadoTipoProductoCommand : IRequest<EditarEstadoTipoProductoCommandDTO>
    {
        public int IdTipoProducto { get; set; }
    }
}
