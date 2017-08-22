using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControlPagosInbaco.Models
{
    public class Establecimiento
    {
        [Required]
        [Key]
        [Display(Name = "Id Establecimiento")]
        public long IdEstablecimiento { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int Estado { get; set; }

        [Display(Name = "Fecha de creación")]
        public string FechaCreacion { get; set; }

        [Display(Name = "Fecha de modificación")]
        public string FechaModificacion { get; set; }

        [Display(Name = "Id Usuario")]
        public long IdUsuario { get; set; }

        [Required]
        [Display(Name = "Nombre de Establecimiento")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Logo")]
        public string Logo { get; set; }

        public virtual ICollection<Grado> Grados { get; set; }
    }
}