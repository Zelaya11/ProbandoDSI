using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FransfordSystem.ViewModels
{
    public class RegistrarUsuarioViewModel
    {
        [Display(Name = "Nombres del Trabajador")]
        [RegularExpression(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.-]+", ErrorMessage = "Ingrese nombres validos")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string nombre { get; set; }

        [Display(Name = "Apellidos del trabajador")]
        [RegularExpression(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.-]+", ErrorMessage = "ingrese apellidos validos")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string apellido { get; set; }

        [Display(Name = "DUI")]
        [RegularExpression(@"^[0-9]{8}-[0-9]{1}$", ErrorMessage = "El formato de DUI no es correcto, asegurese de agregar el guion")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string dui { get; set; }


        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true,
        DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime fechaNac { get; set; }



        [Display(Name = "Genero")]
        [RegularExpression(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.-]+", ErrorMessage = "Ingrese un genero valido")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public char? genero { get; set; }


        [Display(Name = "Cuenta Bancaria")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "ingrese una cuenta bancaria valida")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int? cuentaBancaria { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string correo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string contra { get; set; }





    }
}
