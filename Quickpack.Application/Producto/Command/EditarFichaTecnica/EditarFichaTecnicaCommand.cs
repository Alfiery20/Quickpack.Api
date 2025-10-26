using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Command.EditarFichaTecnica
{
    public class EditarFichaTecnicaCommand : IRequest<EditarFichaTecnicaCommandDTO>
    {
        public int IdProducto { get; set; }
        public double LargoCamara { get; set; }
        public double AnchoCamara { get; set; }
        public double AltoCamara { get; set; }
        public double LargoMaquina { get; set; }
        public double AnchoMaquina { get; set; }
        public double AltoMaquina { get; set; }
        public double BarraSellado { get; set; }
        public double CapacidadBomba { get; set; }
        public int CicloInferior { get; set; }
        public int CicloSuperior { get; set; }
        public double Peso { get; set; }
        public double Potencia { get; set; }
        public int PlacaInsercion { get; set; }
        public string SistemaControl { get; set; }
        public string DeteccionVacioFinal { get; set; }
        public string DeteccionCarne { get; set; }
        public string SoftAir { get; set; }
        public string ControlLiquidos { get; set; }
    }
}
