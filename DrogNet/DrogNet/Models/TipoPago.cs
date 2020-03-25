using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrogNet.Models
{
    public class TipoPago
    {
        public int TipoPagoID { get; set; }
        public string Nombre { get; set; }

        public ICollection<Factura> Factura { get; set; }
    }
}
