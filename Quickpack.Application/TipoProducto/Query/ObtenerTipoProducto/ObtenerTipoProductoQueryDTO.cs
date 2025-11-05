using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.TipoProducto.Query.ObtenerTipoProducto
{
    public class ObtenerTipoProductoQueryDTO
    {
        public int Total { get; set; }
        public int Pagina { get; set; }
        public List<TipoProducto> TipoProducto { get; set; }
    }

    public class TipoProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
