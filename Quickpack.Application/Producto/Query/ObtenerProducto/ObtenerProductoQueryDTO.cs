using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Query.ObtenerProducto
{
    public class ObtenerProductoQueryDTO
    {
        public int Total { get; set; }
        public int Pagina { get; set; }
        public List<Producto> Productos { get; set; }
    }
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Estado { get; set; }
        public string Categoria { get; set; }
        public string UsuarioCrea { get; set; }
        public string FechaCrea { get; set; }
        public string UsuarioModifica { get; set; }
        public string FechaModifica { get; set; }
    }
}
