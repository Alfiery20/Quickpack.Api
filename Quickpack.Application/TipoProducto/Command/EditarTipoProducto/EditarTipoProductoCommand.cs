using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.TipoProducto.Command.EditarTipoProducto
{
    public class EditarTipoProductoCommand : IRequest<EditarTipoProductoCommandDTO>
    {
        public int IdTipoProducto { get; set; }
        public string Nombre { get; set; }
    }
}
