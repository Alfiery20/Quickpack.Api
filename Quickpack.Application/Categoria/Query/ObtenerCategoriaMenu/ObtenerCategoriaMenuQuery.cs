using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.ObtenerCategoriaMenu
{
    public class ObtenerCategoriaMenuQuery : IRequest<IEnumerable<ObtenerCategoriaMenuQueryDTO>>
    {
    }
}
