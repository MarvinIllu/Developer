using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ControlPagosInbaco.Models
{
    public class Grado
    {
        //[Required] //autonumeric
        [Key]
        [Display(Name = "Id Grado")]
        public long IdGrado { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Activo?")]
        public bool estado { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public long IdEstablecimiento { get; set; }

        [Display(Name = "Fecha de creación")]
        public string FechaCreacion { get; set; }

        [Display(Name = "Fecha de modificación")]
        public string FechaModificacion { get; set; }

        [Display(Name = "Id Usuario")]
        public string IdUsuario { get; set; }

        public virtual ICollection<Seccion> Secciones { get; set; }

        public virtual Establecimiento Establecimiento { get; set; }
    }
}