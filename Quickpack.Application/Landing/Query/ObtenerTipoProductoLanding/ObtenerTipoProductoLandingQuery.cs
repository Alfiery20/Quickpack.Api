using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Landing.Query.ObtenerTipoProductoLanding
{
    public class ObtenerTipoProductoLandingQuery : IRequest<ObtenerTipoProductoLandingQueryDTO>
    {
        public int IdTipoProducto { get; set; }
    }
}
