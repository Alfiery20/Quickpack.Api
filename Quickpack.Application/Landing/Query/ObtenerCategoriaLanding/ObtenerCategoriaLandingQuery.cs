using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Landing.Query.ObtenerCategoriaLanding
{
    public class ObtenerCategoriaLandingQuery : IRequest<ObtenerCategoriaLandingQueryDTO>
    {
        public int IdTipoProducto { get; set; }
        public int IdCategoria { get; set; }
    }
}
