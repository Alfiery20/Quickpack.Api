using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Query.ObtenerRol
{
    public class ObtenerRolQueryDTO
    {
        public int Total { get; set; }
        public int Pagina { get; set; }
        public List<Rol> Roles { get; set; }
    }

    public class Rol 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }
}
