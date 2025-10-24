using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Query.ObtenerProducto
{
    public class ObtenerProductoQuery : IRequest<ObtenerProductoQueryDTO>
    {
        public string Termino { get; set; }
        public int IdCategoria { get; set; }
        public int Pagina { get; set; }
        public int Cantidad { get; set; }
    }
}
