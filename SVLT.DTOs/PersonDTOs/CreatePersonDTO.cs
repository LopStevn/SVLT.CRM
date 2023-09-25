using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVLT.DTOs.PersonDTOs
{
    public class CreatePersonDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Apellido no puede tener más de 50 caracteres.")]
        public string LastName { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "El campo Edad es obligatorio.")]
        [MaxLength(2, ErrorMessage = "El campo Edad no puede tener más de 2 caracteres.")]
        public int Age { get; set; }

        [Display(Name = "Estatura")]
        [Required(ErrorMessage = "El campo estatura es obligatorio.")]
        [MaxLength(3, ErrorMessage = "El campo estatura no puede tener más de 3 caracteres.")]
        public decimal Height { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "El campo fecha es obligatorio.")]
        public DateDTO  Birthdate { get; set; }
    }
}
