using Quickpack.Application.Rol.Command.AgregarRol;
using Quickpack.Application.Rol.Command.AsignarPermiso;
using Quickpack.Application.Rol.Command.EditarEstadoRol;
using Quickpack.Application.Rol.Command.EditarRol;
using Quickpack.Application.Rol.Query.ObtenerPermisoRol;
using Quickpack.Application.Rol.Query.ObtenerRol;
using Quickpack.Application.Rol.Query.ObtenerRolMenu;
using Quickpack.Application.Rol.Query.VerRol;
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
        Task<VerRolQueryDTO> VerRole(VerRolQuery query);
        Task<EditarRolCommandDTO> EditarRol(EditarRolCommand command);
        Task<EditarEstadoRolCommandDTO> EditarEstadoRol(EditarEstadoRolCommand command);
        Task<IEnumerable<ObtenerPermisoRolQueryDTO>> ObtenerPermisosRoles(ObtenerPermisoRolQuery query);
        Task<AsignarPermisoCommandDTO> AsignarPermiso(AsignarPermisoCommand command);
        Task<IEnumerable<ObtenerRolMenuQueryDTO>> ObtenerRoleMenu();
    }
}
