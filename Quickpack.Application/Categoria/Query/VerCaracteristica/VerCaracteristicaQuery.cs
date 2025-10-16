using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.VerCaracteristica
{
    public class VerCaracteristicaQuery : IRequest<VerCaracteristicaQueryDTO>
    {
        public int IdCaracteristica { get; set; }
    }
}
