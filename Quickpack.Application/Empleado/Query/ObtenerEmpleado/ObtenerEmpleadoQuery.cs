using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Empleado.Query.ObtenerEmpleado
{
    public class ObtenerEmpleadoQuery : IRequest<ObtenerEmpleadoQueryDTO>
    {
        public string Nombre { get; set; }
        public string NroDocumento { get; set; }
        public int Pagina { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
    }
}
