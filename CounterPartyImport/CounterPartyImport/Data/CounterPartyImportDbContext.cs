using CounterPartyImport.Data.Mappings;
using CounterPartyImport.Entities;
using Microsoft.EntityFrameworkCore;

namespace CounterPartyImport.Data
{
    public class CounterPartyImportDbContext : DbContext
    {
        public CounterPartyImportDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
    }
}