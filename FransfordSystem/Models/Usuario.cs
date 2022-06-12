using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FransfordSystem.Models
{
    public class Usuario : IdentityUser 
    {
        [Display(Name = "Nombres del Trabajador")]
        [RegularExpression(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.-]+", ErrorMessage = "Ingrese nombres validos")]
        //[Required(ErrorMessage = "Este campo es obligatorio")]
        public string? nombreTrabajador { get; set; }
        


        [Display(Name = "Apellidos del trabajador")]
        [RegularExpression(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.-]+", ErrorMessage = "ingrese apellidos validos")]
       // [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? apellidoTrabajador { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime fechaNacimiento { get; set; }

        [Display(Name = "Genero")]
        [RegularExpression(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.-]+", ErrorMessage = "Ingrese un genero valido")]
       // [Required(ErrorMessage = "Este campo es obligatorio")]
        public char? genero { get; set; }


        [Display(Name = "DUI")]
        [RegularExpression(@"^[0-9]{8}-[0-9]{1}$", ErrorMessage = "El formato de DUI no es correcto, asegurese de agregar el guion")]
       // [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? dui { get; set; }

        [Display(Name = "Cuenta Bancaria")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Ingrese una cuenta bancaria valida")]
        //[Required(ErrorMessage = "Este campo es obligatorio")]
        public int? cuentaBancaria { get; set; }

        public ICollection<Cliente>? clientes { get; set; }




    }
}
