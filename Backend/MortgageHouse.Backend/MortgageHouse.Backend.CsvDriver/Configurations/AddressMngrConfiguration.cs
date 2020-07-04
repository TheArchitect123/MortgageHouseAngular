using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MortgageHouse.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageHouse.Backend.CsvDriver.Configurations
{
    public class AddressMngrConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address));
        }
    }
}
