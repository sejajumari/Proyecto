using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrogNet.Models
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public int VendedorID { get; set; }

        public int ClienteID { get; set; }

        public int TipoPagoID { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public bool Domicilio { get; set; }

        public string Referencia { get; set; }

        public string Direccion { get; set; }

        public ICollection<VentaProducto> ventaProducto { get; set; }

        public Vendedor Vendedor { get; set; }
        public Cliente Cliente { get; set; }
        public TipoPago TipoPago { get; set; }
    }
}
