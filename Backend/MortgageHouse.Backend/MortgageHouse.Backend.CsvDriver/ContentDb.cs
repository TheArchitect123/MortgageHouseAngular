using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MortgageHouse.Backend.Constants;
using MortgageHouse.Backend.CsvDriver.Configurations;
using MortgageHouse.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortgageHouse.Backend.CsvDriver
{
    public class ContentDb : DbContext
    {
        public ContentDb(DbContextOptions options) : base(options) {
            //this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema(DbConstants.MngrSchema);

            //Configurations
            modelBuilder.ApplyConfiguration(new AddressMngrConfiguration());
            modelBuilder.ApplyConfiguration(new ContactMngrConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        private void DetachAllEntries()
        {
            foreach (var entry in this.ChangeTracker.Entries().ToList())
                entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public override EntityEntry Update(object entity)
        {
            DetachAllEntries();
            return base.Update(entity);
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            DetachAllEntries();
            return base.Update(entity);
        }

        //Data
        public DbSet<Address> sAddresses { get; set; }
        public DbSet<Contact> sContacts { get; set; }
    }
}
