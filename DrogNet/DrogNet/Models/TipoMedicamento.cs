using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrogNet.Models
{
    public class TipoMedicamento
    {
        public int TipoMedicamentoID { get; set; }
        [Required(ErrorMessage = "Ingrese un Nombre")]
        [StringLength(50, ErrorMessage = "{0} debe estar entre {2} y {1}.", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
