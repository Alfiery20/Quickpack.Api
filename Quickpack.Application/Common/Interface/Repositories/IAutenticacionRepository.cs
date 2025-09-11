using Quickpack.Application.Autenticacion.command.IniciarSesion;
using Quickpack.Application.Autenticacion.command.ObtenerMenu;

namespace Quickpack.Application.Common.Interface.Repositories
{
    public interface IAutenticacionRepository
    {
        Task<IniciarSesionCommandDTO> IniciarSesion(IniciarSesionCommand command);
        Task<IEnumerable<ObtenerMenuCommandDTO>> ObtenerMenu(ObtenerMenuCommand command);
    }
}
