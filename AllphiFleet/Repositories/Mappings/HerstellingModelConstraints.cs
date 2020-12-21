using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class HerstellingModelConstraints
    {
        public static void OnModelCreatingHerstelling(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Herstelling>()
               .HasKey(h => h.Id);

            modelBuilder.Entity<Herstelling>()
                .Property(h => h.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Herstelling>()
                .Property(h => h.DatumHerstelling)
                .IsRequired();

            modelBuilder.Entity<Herstelling>()
                .Property(h => h.SchadeOmschrijving)
                .IsRequired();
        }
    }
}
