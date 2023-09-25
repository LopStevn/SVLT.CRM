using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVLT.DTOs.PersonDTOs
{
    public class SearchResultPersonDTO
    {
        public int CounRow { get; set; }

        public List<PersonDTO> Data { get; set; }

        public class PersonDTO
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string Name { get; set; }

            [Display(Name = "Apellido")]
            public string LastName { get; set; }

            [Display(Name = "Edad")]
            public int Age { get; set; }

            [Display(Name = "Estatura")]
            public double Height { get; set; }

            [Display(Name = "Fecha de Nacimiento")]
            public DateOnly Birthdate { get; set; }
        }
    }
}
