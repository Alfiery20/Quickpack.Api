using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Command.EditarEstadoRol
{
    public class EditarEstadoRolCommand : IRequest<EditarEstadoRolCommandDTO>
    {
        public int IdRol { get; set; }
    }
}
