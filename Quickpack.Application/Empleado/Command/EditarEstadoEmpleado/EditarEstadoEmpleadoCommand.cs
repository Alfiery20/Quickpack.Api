using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Empleado.Command.EditarEstadoEmpleado
{
    public class EditarEstadoEmpleadoCommand : IRequest<EditarEstadoEmpleadoCommandDTO>
    {
        public int IdEmpleado { get; set; }
    }
}
