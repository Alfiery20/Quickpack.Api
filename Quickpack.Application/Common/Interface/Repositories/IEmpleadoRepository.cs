using Quickpack.Application.Empleado.Command.AgregarEmpleado;
using Quickpack.Application.Empleado.Command.EditarEmpleado;
using Quickpack.Application.Empleado.Command.EditarEstadoEmpleado;
using Quickpack.Application.Empleado.Query.ObtenerEmpleado;
using Quickpack.Application.Empleado.Query.VerEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Common.Interface.Repositories
{
    public interface IEmpleadoRepository
    {
        Task<ObtenerEmpleadoQueryDTO> ObtenerEmpleado(ObtenerEmpleadoQuery query);
        Task<AgregarEmpleadoCommandDTO> AgregarEmpleado(AgregarEmpleadoCommand command);
        Task<EditarEstadoEmpleadoCommandDTO> EditarEstadoEmpleado(EditarEstadoEmpleadoCommand command);
        Task<VerEmpleadoQueryDTO> VerEmpleado(VerEmpleadoQuery query);
        Task<EditarEmpleadoCommandDTO> EditarEmpleado(EditarEmpleadoCommand command);
    }
}
