using SVLT.CRM.API.Models.DAL;
using SVLT.CRM.API.Models.EN;
using SVLT.DTOs;
using SVLT.DTOs.PersonDTOs;
using System.Globalization;
using System.Text.Json;

namespace SVLT.CRM.API.Endpoints
{
    public static class PersonEndpoint
    {
        public static void AddPersonEndpoints(this WebApplication app)
        {
            app.MapPost("/person/search", async (SearchQueryPersonDTO personDTO, PersonDAL personDAL) =>
            {
                var customer = new Person
                {
                    Name = personDTO.Name_Like != null ? personDTO.Name_Like : string.Empty,
                    LastName = personDTO.LastName_Like != null ? personDTO.LastName_Like : string.Empty
                };

                var people = new List<Person>();
                int countRow = 0;

                if (personDTO.SendRowCount == 2)
                {
                    people = await personDAL.Search(customer, skip: personDTO.Skip, take: personDTO.Take);
                    if (people.Count > 0)
                        countRow = await personDAL.CountSearch(customer);
                }
                else
                {
                    people = await personDAL.Search(customer, skip: personDTO.Skip, take: personDTO.Take);
                }

                var personResult = new SearchResultPersonDTO
                {
                    Data = new List<SearchResultPersonDTO.PersonDTO>(),
                    CounRow = countRow
                };

                people.ForEach(s =>
                {
                    personResult.Data.Add(new SearchResultPersonDTO.PersonDTO
                    {
                        Id = s.Id,
                        Name = s.Name,
                        LastName = s.LastName,
                        Age = s.Age,
                        Height = s.Height,
                        Birthdate = s.Birthdate
                    }); 
                });
                return personResult;
            });

            app.MapGet("/person/{id}", async (int id, PersonDAL personDAL) =>
            {
                var person = await personDAL.GetById(id);

                var personResult = new GetIdResultPersonDTO
                {
                    Id = person.Id,
                    Name = person.Name,
                    LastName = person.LastName,
                    Age = person.Age,
                    Height = person.Height,
                    Birthdate = person.Birthdate.GetDateDTO()
                };

                if (personResult.Id > 0)
                    return Results.Ok(personResult);
                else
                    return Results.NotFound(person);
            });

            app.MapPost("/person", async (CreatePersonDTO personDTO, PersonDAL personDAL) =>
            {
                 

                var person = new Person
                {
                    Name = personDTO.Name,
                    LastName = personDTO.LastName,
                    Age = personDTO.Age,
                    Height = personDTO.Height,
                    Birthdate = personDTO.Birthdate_temp
                    //Birthdate =personDTO.Birthdate.ToDateTime()
                };

                int result = await personDAL.Create(person);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            app.MapPut("/person", async (EditPersonDTO personDTO, PersonDAL personDAL) =>
            {
                var person = new Person
                {
                    Id = personDTO.Id,
                    Name = personDTO.Name,
                    LastName = personDTO.LastName,
                    Age = personDTO.Age,
                    Height = personDTO.Height,
                    Birthdate = personDTO.Birthdate
                };

                int result = await personDAL.Edit(person);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            app.MapDelete("/person/{id}", async (int id, PersonDAL personDAL) =>
            {
                int result = await personDAL.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
        }
    }
}
