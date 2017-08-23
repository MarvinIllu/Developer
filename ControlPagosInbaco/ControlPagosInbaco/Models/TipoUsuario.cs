using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControlPagosInbaco.Models
{
    public class TipoUsuario
    {
        [Required]
        [Key]
        [Display(Name = "Id Tipo Usuario")]
        public string IdTipoUsuario { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }
}