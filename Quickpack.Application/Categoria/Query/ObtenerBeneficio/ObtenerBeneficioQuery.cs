using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.ObtenerBeneficio
{
    public class ObtenerBeneficioQuery : IRequest<ObtenerBeneficioQueryDTO>
    {
        public int IdCategoria { get; set; }
    }
}
