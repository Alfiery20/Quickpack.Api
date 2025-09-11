using MediatR;

namespace Quickpack.Application.Autenticacion.command.ObtenerMenu
{
    public class ObtenerMenuCommand : IRequest<IEnumerable<ObtenerMenuCommandDTO>>
    {
        public int IdRol { get; set; }
        public int IdUsuario { get; set; }
    }
}
