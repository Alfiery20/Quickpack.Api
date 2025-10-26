using System.Security.Claims;

namespace Quickpack.Application.Common.Interface
{
    public interface IJwtService
    {
        string Generate(Claim[] claims, bool recordar, DateTime? experisUtc = null, string audience = null);
    }
}
