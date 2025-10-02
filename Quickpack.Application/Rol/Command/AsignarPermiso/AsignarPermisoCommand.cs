using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Command.AsignarPermiso
{
    public class AsignarPermisoCommand : IRequest<AsignarPermisoCommandDTO>
    {
        public int IdPermiso { get; set; }
        public int IdMenu { get; set; }
        public int IdRol { get; set; }
    }
}
