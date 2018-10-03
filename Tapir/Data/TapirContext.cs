using Microsoft.EntityFrameworkCore;

namespace Tapir.Models
{
    public class TapirContext : DbContext
    {
        public TapirContext(DbContextOptions<TapirContext> options)
            : base(options)
        { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BusinessSector> BusinessSectors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
