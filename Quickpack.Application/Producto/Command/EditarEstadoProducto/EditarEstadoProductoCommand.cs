using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Command.EditarEstadoProducto
{
    public class EditarEstadoProductoCommand : IRequest<EditarEstadoProductoCommandDTO>
    {
        public int IdProducto { get; set; }
    }
}
