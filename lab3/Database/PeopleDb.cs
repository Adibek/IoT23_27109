using Lab1.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            
        }

        private void ConfigurePersonEnitity(EntityTypeBuilder<PersonEntity> entity)
        {
            entity.ToTable("Person");
            entity.Property(p=>p.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(p=>p.LastName).IsRequired().HasMaxLength(200);
        }
    
        public DbSet<PersonEntity> People {get; set; }
    
    }

    
}