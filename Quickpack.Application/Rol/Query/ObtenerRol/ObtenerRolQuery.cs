using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Query.ObtenerRol
{
    public class ObtenerRolQuery : IRequest<ObtenerRolQueryDTO>
    {
        public string Termino { get; set; }
        public int Pagina { get; set; }
        public int Cantidad { get; set; }
    }
}
