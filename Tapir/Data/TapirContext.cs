using Microsoft.EntityFrameworkCore;

namespace Tapir.Models
{
    public class TapirContext : DbContext
    {
        public TapirContext(DbContextOptions<TapirContext> options)
            : base(options)
        { }

        public DbSet<Person> Person { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Employment> Employment { get; set; }
    }
}
