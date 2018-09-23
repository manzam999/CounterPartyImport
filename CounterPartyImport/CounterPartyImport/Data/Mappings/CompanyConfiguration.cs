using CounterPartyImport.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CounterPartyImport.Data.Mappings
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasIndex(c => c.ExternalId)
                .IsUnique()
                .HasName("AlternateKey_ExternalId");

            builder.Property(c => c.Fax)
                .HasMaxLength(50);

            builder.Property(c => c.Phone)
                .HasMaxLength(50);
        }
    }
}
