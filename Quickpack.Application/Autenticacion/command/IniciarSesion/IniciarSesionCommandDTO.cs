namespace Quickpack.Application.Autenticacion.command.IniciarSesion
{
    public class IniciarSesionCommandDTO
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
    }
}
