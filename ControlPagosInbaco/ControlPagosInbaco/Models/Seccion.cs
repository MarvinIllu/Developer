using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web;

namespace ControlPagosInbaco.Models
{
    public class Seccion
    {
        //[Required] //autonumeric
        [Key]
        [Display(Name = "Id Seccion")]
        public long IdSeccion { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Activo?")]
        public bool Estado { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public long IdGrado { get; set; }

        [Display(Name = "Fecha de creación")]
        public string FechaCreacion { get; set; }
        [Display(Name = "Fecha de modificación")]

        public String FechaModificacion { get; set; }
        [Display(Name = "Id Usuario")]
        public String IdUsuario { get; set; }


        public virtual Grado Grado { get; set; }

    }
}