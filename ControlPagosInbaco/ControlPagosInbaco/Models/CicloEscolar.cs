using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web;


namespace ControlPagosInbaco.Models
{
    public class CicloEscolar
    {
        [Key]
        [Display(Name = "Id Ciclo")]
        public long IdCiclo { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }


        [Required]
        [Display(Name = "Activo?")]
        public bool Estado { get; set; }

        [Display(Name = "Fecha de creación")]
        public string FechaCreacion { get; set; }


        [Display(Name = "Fecha de modificación")]
        public String FechaModificacion { get; set; }


        [Display(Name = "Id Usuario")]
        public String IdUsuario { get; set; }

    }
}