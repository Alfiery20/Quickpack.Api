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
        public List<CaracteristicaLanding> Caracteristicas { get; set; }
        public List<FichaTecnicaLanding> FichasTecnicas { get; set; }
    }

    public class ProductoLanding
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Multimedia { get; set; }
        public double Precio { get; set; }
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

    public class CaracteristicaLanding
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Multimedia { get; set; }
    }

    public class FichaTecnicaLanding
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public double AltoCamara { get; set; }
        public double AnchoCamara { get; set; }
        public double LargoCamara { get; set; }
        public double AltoMaquina { get; set; }
        public double AnchoMaquina { get; set; }
        public double LargoMaquina { get; set; }
        public double BarraSellado { get; set; }
        public int CapacidadBomba { get; set; }
        public int CicloSuperior { get; set; }
        public int CicloInferior { get; set; }
        public double Peso { get; set; }
        public int PlacaInsercion { get; set; }
        public string SistemaControl { get; set; }
        public string DeteccionVacioFinal { get; set; }
        public string DeteccionCarne { get; set; }
        public string SoftAir { get; set; }
        public string ControlLiquidos { get; set; }
        public double Potencia { get; set; }
    }
}
