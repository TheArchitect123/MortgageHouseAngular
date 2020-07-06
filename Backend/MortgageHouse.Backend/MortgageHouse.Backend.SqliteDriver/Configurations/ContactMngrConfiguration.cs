using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MortgageHouse.Backend.Domain.Entities;

namespace MortgageHouse.Backend.SqliteDriver.Configurations
{
    public class ContactMngrConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable(nameof(Contact));
        }
    }
}
