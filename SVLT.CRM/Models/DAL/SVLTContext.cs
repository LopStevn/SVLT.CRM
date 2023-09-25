using Microsoft.EntityFrameworkCore;
using SVLT.CRM.API.Models.EN;

namespace SVLT.CRM.API.Models.DAL
{
    public class SVLTContext : DbContext
    {
        public SVLTContext(DbContextOptions<SVLTContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
    }
}
