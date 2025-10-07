using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.TipoProducto.Query.VerTipoProducto
{
    public class VerTipoProductoQuery : IRequest<VerTipoProductoQueryDTO>
    {
        public int IdTipoProducto { get; set; }
    }
}
