using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ControlPagosInbaco.Models
{
    public class Perfil
    {
        [Key]
        [Display(Name = "Id Perfil")]
        public long IdPerfil { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

         [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }

         [Display(Name = "Codigo")]
        public string Codigo { get; set; }

         [Display(Name = "Telèfono")]
        public string Telefono { get; set; }

         [Display(Name = "Direcciòn")]
        public string Direccion { get; set; }


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