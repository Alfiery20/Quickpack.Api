using Quickpack.Application.Common.Interface;

namespace Quickpack.Api.Services
{
    public class CurrentUser : ICurrentUser
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get; set; }
        public string RolId { get; set; }
        public string Rol { get; set; }
    }
}
