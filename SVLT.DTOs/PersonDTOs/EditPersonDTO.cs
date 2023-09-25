﻿using System;
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
            Age = getIdResultPersonDTO.Age.ToString();
            Height = getIdResultPersonDTO.Height;
            Birthdate = getIdResultPersonDTO.Birthdate;
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
        [MaxLength(2, ErrorMessage = "El campo Edad no puede tener más de 2 caracteres.")]
        public string? Age { get; set; }

        [Display(Name = "Estatura")]
        [Required(ErrorMessage = "El campo estatura es obligatorio.")]
        [MaxLength(3, ErrorMessage = "El campo estatura no puede tener más de 3 caracteres.")]
        public double Height { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "El campo fecha es obligatorio.")]
        public DateOnly Birthdate { get; set; }
    }
}