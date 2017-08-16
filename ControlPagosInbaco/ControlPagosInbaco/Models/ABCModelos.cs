using System.ComponentModel.DataAnnotations;

namespace ControlPagosInbaco.Models
{
    public class ABCModelos
    {
        public class Articulo
        {
            [Required]
            [Key]
            [Display(Name = "Id Artículo")]
            public long IdArticulo { get; set; }

            /*[DataType(DataType.Password)]
            [Display(Name = "Confirme la contraseña nueva")]
            [Compare("NewPassword", ErrorMessage = "La contraseña nueva y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }*/
        }
    }
}