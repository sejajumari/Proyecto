using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrogNet.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        [Required(ErrorMessage = "Ingrese Un Nombre")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public int TipoMedicamentoID { get; set; }
        public TipoMedicamento TipoMedicamento { get; set; }
        [Required(ErrorMessage = "Ingrese Un Laboratorio")]
        [Display(Name = "Laboratorio")]
        public string Laboratorio { get; set; }
        public Decimal Precio { get; set; }
        public string Lote { get; set; }
        [Required]
        [Display(Name = "Imagen")]
        public string PathFile { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }

        public ICollection<VentaProducto> VentaProducto { get; set; }

 
    }
}
