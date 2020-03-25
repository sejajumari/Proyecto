using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrogNet.Models
{
    public class VentaProducto
    {
        public int VentaProductoID { get; set; }
        public int FacturaID { get; set; }
        public int ProductoID { get; set; }
        public string Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public Factura Factura { get; set; }
        public Producto Producto { get; set; }

    }
}
