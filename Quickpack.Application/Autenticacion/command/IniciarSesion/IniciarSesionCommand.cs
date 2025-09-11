using MediatR;

namespace Quickpack.Application.Autenticacion.command.IniciarSesion
{
    public class IniciarSesionCommand : IRequest<IniciarSesionCommandDTO>
    {
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
