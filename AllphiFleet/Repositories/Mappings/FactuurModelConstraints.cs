using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class FactuurModelConstraints
    {
        public static void OnModelCreatingFactuur(this ModelBuilder modelBuilder)
        {
            //factuur
            modelBuilder.Entity<Factuur>()
               .HasKey(f => f.Id);

            modelBuilder.Entity<Factuur>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Factuur>()
                .Property(f => f.NaamGefactureerde)
                .IsRequired();
        }
    }
}
