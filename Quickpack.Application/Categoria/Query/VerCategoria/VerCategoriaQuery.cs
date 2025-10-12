using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.VerCategoria
{
    public class VerCategoriaQuery : IRequest<VerCategoriaQueryDTO>
    {
        public int IdCategoria { get; set; }
    }
}
