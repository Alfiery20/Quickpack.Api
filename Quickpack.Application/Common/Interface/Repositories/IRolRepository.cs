using Quickpack.Application.Rol.Command;
using Quickpack.Application.Rol.Query.ObtenerRol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Common.Interface.Repositories
{
    public interface IRolRepository
    {
        Task<ObtenerRolQueryDTO> ObtenerRoles(ObtenerRolQuery query);
        Task<AgregarRolCommandDTO> AgregarRol(AgregarRolCommand command);
    }
}
