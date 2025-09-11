using Quickpack.Application.Common.Dtos;

namespace Quickpack.Application.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(MensajeUsuarioDTO message)
            : base(message)
        {
        }
    }
}
