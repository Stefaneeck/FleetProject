using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories.ModelConstraints
{
    public class FactuurModelConstraints
    {
        public static void OnModelCreatingFactuur(ModelBuilder modelBuilder)
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
