namespace Quickpack.Application.Autenticacion.command.ObtenerMenu
{
    public class ObtenerMenuCommandDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public int IdMenuPadre { get; set; }
        public int Orden { get; set; }
        public string Icono { get; set; }
        public List<ObtenerMenuCommandDTO> MenuHijo { get; set; }
    }
}
