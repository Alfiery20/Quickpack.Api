using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.TipoProducto.Command.AgregarTipoProducto
{
    public class AgregarTipoProductoCommand : IRequest<AgregarTipoProductoCommandDTO>
    {
        public string Nombre { get; set; }
    }
}
