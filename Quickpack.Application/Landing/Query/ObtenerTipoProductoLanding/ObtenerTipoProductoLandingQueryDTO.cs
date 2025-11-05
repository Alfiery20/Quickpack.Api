using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Landing.Query.ObtenerTipoProductoLanding
{
    public class ObtenerTipoProductoLandingQueryDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Multimedia { get; set; }
        public List<CategoriaLanding> Categorias { get; set; }
    }

    public class CategoriaLanding
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Multimedia { get; set; }
    }
}
