using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [Range(0, 150, ErrorMessage = "La edad debe estar entre 0 y 150.")]
        public int Age { get; set; }

        [Display(Name = "Estatura")]
        [Required(ErrorMessage = "El campo estatura es obligatorio.")]
        [Range(0.50, 3.00, ErrorMessage = "La estatura no debe ser mayor a 3m")]
        public decimal Height { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "El campo fecha es obligatorio.")]
        //public DateDTO  Birthdate { get; set; }

        //private DateTime m_Birthdate_temp;
        public DateTime Birthdate_temp { get; set; }
        //public DateTime 
        //[JsonIgnore]
        //public DateTime Birthdate_temp
        //{
        //    get
        //    {
        //       if (Birthdate != null && Birthdate.Year>0)
        //            m_Birthdate_temp = Birthdate.ToDateTime();
        //        else
        //            m_Birthdate_temp = DateTime.Now;
        //        return m_Birthdate_temp;
        //    }
        //    set
        //    {
        //        m_Birthdate_temp = value;
        //        Birthdate = m_Birthdate_temp.GetDateDTO();
        //    }
        //}
    }
}
