using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories.ModelConstraints
{
    public class HerstellingModelConstraints
    {
        public static void OnModelCreatingHerstelling(ModelBuilder modelBuilder)
        {
            //herstelling
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
