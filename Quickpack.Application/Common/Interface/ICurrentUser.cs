namespace Quickpack.Application.Common.Interface
{
    public interface ICurrentUser
    {
        string Id { get; set; }
        string Nombre { get; set; }
        string ApellidoPaterno { get; set; }
        string ApellidoMaterno { get; set; }
        string NombreCompleto { get; set; }
        string RolId { get; set; }
        string Rol { get; set; }
    }
}
