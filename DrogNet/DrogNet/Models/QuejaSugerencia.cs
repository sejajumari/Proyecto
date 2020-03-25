using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrogNet.Models
{
    public class QuejaSugerencia
    {
        public int QuejaSugerenciaID { get; set; }
    
        public bool Tema { get; set; }
        [Required(ErrorMessage = "Ingrese una descripcion")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]

        [Required(ErrorMessage = "Ingrese una Fecha")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
    }
}
