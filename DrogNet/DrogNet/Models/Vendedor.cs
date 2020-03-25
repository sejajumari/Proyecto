using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrogNet.Models
{
    public class Vendedor
    {
        public int VendedorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
        public ICollection<Factura> Factura { get; set; }
    }
}
