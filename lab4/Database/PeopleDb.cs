using Lab1.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using lab3.Database.Entities;

namespace Lab1.Database
{
    public class PeopleDb:DbContext
    {
        public PeopleDb(DbContextOptions<PeopleDb> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigurePersonEnitity(modelBuilder.Entity<PersonEntity>());
            ConfigureAddressEntity(modelBuilder.Entity<Address>());
            
            
        }

        private void ConfigurePersonEnitity(EntityTypeBuilder<PersonEntity> entity)
        {
            entity.ToTable("Person");
            entity.Property(p=>p.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(p=>p.LastName).IsRequired().HasMaxLength(200);

            entity.HasOne(a => a.address)
            .WithMany(m => m.people)
            .HasForeignKey(fk => fk.AddressId);
        }

        private void ConfigureAddressEntity(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Address");
            entity.Property(a => a.City).IsRequired().HasMaxLength(200);
            entity.Property(a => a.AddressLine).IsRequired().HasMaxLength(200);
        }
    
        public DbSet<PersonEntity> People {get; set; }
        public DbSet<Address> Address {get; set;}
    
    }

    
}