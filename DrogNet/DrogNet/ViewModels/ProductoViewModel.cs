using DrogNet.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrogNet.ViewModels
{
    public class ProductoViewModel
    {
        public int ProductoID { get; set; }
        [Required(ErrorMessage = "Ingrese un Nombre")]
        [Display(Name = " Nombre")]
        public string Nombre { get; set; }

        public int TipoMedicamentoID { get; set; }
        public TipoMedicamento TipoMedicamento { get; set; }
        [Required(ErrorMessage = "Ingrese un Laboratorio")]
        [Display(Name = "Laboratorio")]
        public string Laboratorio { get; set; }
        public Decimal Precio { get; set; }
        public string Lote { get; set; }
        [Required]
        [Display(Name = "Imagen")]
        public  IFormFile Photo { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }

        public ICollection<VentaProducto> VentaProducto { get; set; }
    }
}
