using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Empleado.Command.EditarEmpleado
{
    public class EditarEmpleadoCommand : IRequest<EditarEmpleadoCommandDTO>
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public int IdRol { get; set; }
    }
}
