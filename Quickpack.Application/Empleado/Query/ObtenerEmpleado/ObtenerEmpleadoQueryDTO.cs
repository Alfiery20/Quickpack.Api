using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Empleado.Query.ObtenerEmpleado
{
    public class ObtenerEmpleadoQueryDTO
    {
        public int Total { get; set; }
        public int Pagina { get; set; }
        public List<Empleado> Empleados { get; set; }
    }

    public class Empleado
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
    }
}
