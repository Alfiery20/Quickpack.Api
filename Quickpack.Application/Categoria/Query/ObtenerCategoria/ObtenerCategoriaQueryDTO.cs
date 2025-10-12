using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.ObtenerCategoria
{
    public class ObtenerCategoriaQueryDTO
    {
        public int Total { get; set; }
        public int Pagina { get; set; }
        public List<Categoria> Categorias { get; set; }
    }

    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoProducto { get; set; }
        public string Estado { get; set; }
    }
}
