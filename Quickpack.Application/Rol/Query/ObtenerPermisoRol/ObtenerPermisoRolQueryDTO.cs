using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Query.ObtenerPermisoRol
{
    public class ObtenerPermisoRolQueryDTO
    {
        public int IdMenu { get; set; }
        public string Nombre { get; set; }
        public int Padre { get; set; }
        public int IsPermiso { get; set; }
        public List<ObtenerPermisoRolQueryDTO> MenusHijos { get; set; }
    }
}
