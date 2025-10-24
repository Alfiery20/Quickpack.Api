﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Query.VerProducto
{
    public class VerProductoQueryDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Multimedia { get; set; }
        public int IdCategoria { get; set; }
    }
}
