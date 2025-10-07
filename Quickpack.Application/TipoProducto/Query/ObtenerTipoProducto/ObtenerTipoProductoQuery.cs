using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.TipoProducto.Query.ObtenerTipoProducto
{
    public class ObtenerTipoProductoQuery : IRequest<ObtenerTipoProductoQueryDTO>
    {
        public string Termino { get; set; }
        public int Pagina { get; set; }
        public int Cantidad { get; set; }
    }
}
