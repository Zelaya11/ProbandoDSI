using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace FransfordSystem.Models
{
    public class Unidad
    {

        [Key]
        [Required]
        public int idUnidad { get; set; }

        public ICollection<Descripcion> descripcion { get; set; }

        [Display(Name = "Nombre de la unidad")]
        [RegularExpression(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.-]+", ErrorMessage = "Ingrese nombres con caracteres válidos")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string nombreUnidad { get; set; }

    }
}
