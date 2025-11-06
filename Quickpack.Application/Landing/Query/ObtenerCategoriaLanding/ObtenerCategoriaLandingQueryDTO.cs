using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Landing.Query.ObtenerCategoriaLanding
{
    public class ObtenerCategoriaLandingQueryDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Multimedia { get; set; }
        public List<ProductoLanding> Producto { get; set; }
        public BeneficioCategoriaLanding Beneficios { get; set; }
    }

    public class ProductoLanding
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Multimedia { get; set; }
    }

    public class BeneficioCategoriaLanding
    {
        public string Descripcion { get; set; }
        public List<BeneficioLanding> Beneficios { get; set; }
    }

    public class BeneficioLanding
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
