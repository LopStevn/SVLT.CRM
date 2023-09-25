
using Microsoft.EntityFrameworkCore;
using SVLT.CRM.API.Models.EN;

namespace SVLT.CRM.API.Models.DAL
{
    public class PersonDAL
    {
        readonly SVLTContext _context;

        public PersonDAL(SVLTContext Context)
        {
            _context = Context;
        }

        public async Task<int> Create(Person person)
        {
            _context.Add(person);
            return await _context.SaveChangesAsync();
        }

        public async Task<Person> GetById(int id)
        {
            var person = await _context.People.FirstOrDefaultAsync(s => s.Id == id);
            return person != null ? person : new Person();
        }

        public async Task<int> Edit(Person person)
        {
            int result = 0;
            var personUpdate = await GetById(person.Id);
            if (personUpdate.Id != 0)
            {
                personUpdate.Name = person.Name;
                personUpdate.LastName = person.LastName;
                personUpdate.Age = person.Age;
                personUpdate.Height = person.Height;
                personUpdate.Birthdate = person.Birthdate;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            var personDelete = await GetById(id);
            if (personDelete.Id > 0)
            {
                _context.People.Remove(personDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        private IQueryable<Person> Query(Person person)
        {
            var query = _context.People.AsQueryable();
            if (!string.IsNullOrWhiteSpace(person.Name))
                query = query.Where(s => s.Name.Contains(person.Name));
            if (!string.IsNullOrWhiteSpace(person.LastName))
                query = query.Where(s => s.LastName.Contains(person.LastName));
            return query;
        }

        public async Task<int> CountSearch(Person person)
        {
            return await Query(person).CountAsync();
        }

        public async Task<List<Person>> Search(Person person, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(person);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
