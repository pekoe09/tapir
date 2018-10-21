using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Tapir.Models
{
    public class TapirContext : IdentityDbContext<TapirUser>
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
