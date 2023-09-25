namespace SVLT.CRM.API.Models.EN
{
    public class Person
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public double Height { get; set; }

        public DateOnly Birthdate { get; set; }
    }
}
