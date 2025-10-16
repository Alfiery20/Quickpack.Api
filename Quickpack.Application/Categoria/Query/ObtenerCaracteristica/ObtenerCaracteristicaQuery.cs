using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.ObtenerCaracteristica
{
    public class ObtenerCaracteristicaQuery : IRequest<IEnumerable<ObtenerCaracteristicaQueryDTO>>
    {
        public int IdCategoria { get; set; }
    }
}
