using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Query.VerProducto
{
    public class VerProductoQuery : IRequest<VerProductoQueryDTO>
    {
        public int IdProducto { get; set; }
    }
}
