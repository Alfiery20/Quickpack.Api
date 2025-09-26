using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Query.ObtenerPermisoRol
{
    public class ObtenerPermisoRolQuery : IRequest<IEnumerable<ObtenerPermisoRolQueryDTO>>
    {
        public int IdRol { get; set; }
    }
}
