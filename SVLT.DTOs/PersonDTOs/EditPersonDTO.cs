using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVLT.DTOs.PersonDTOs
{
    public class EditPersonDTO
    {
        public EditPersonDTO(GetIdResultPersonDTO getIdResultPersonDTO)
        {
            Id = getIdResultPersonDTO.Id;
            Name = getIdResultPersonDTO.Name;
            LastName = getIdResultPersonDTO.LastName;
            Age = getIdResultPersonDTO.Age;
            Height = getIdResultPersonDTO.Height;
            Birthdate = getIdResultPersonDTO.Birthdate.ToDateTime();
        }

        public EditPersonDTO()
        {
            Name = string.Empty;
            LastName = string.Empty;
        }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 carácteres.")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo apellido es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Apellido no puede tener más de 50 carácteres.")]
        public string LastName { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "El campo Edad es obligatorio.")]
        [Range(0, 150, ErrorMessage = "La edad debe estar entre 0 y 150.")]
        public int Age { get; set; }

        [Display(Name = "Estatura")]
        [Required(ErrorMessage = "El campo estatura es obligatorio.")]
        [Range(0.50, 3.00, ErrorMessage = "La estatura no debe ser mayor a 3m")]
        public decimal Height { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "El campo fecha es obligatorio.")]
        public DateTime Birthdate { get; set; }
    }
}
