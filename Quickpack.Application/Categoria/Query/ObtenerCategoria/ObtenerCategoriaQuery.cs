using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.ObtenerCategoria
{
    public class ObtenerCategoriaQuery : IRequest<ObtenerCategoriaQueryDTO>
    {
        public string Termino { get; set; }
        public int Cantidad { get; set; }
        public int Pagina { get; set; }
    }
}
