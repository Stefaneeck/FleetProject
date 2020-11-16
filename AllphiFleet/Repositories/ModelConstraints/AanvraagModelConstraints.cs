using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories.ModelConstraints
{
    public class AanvraagModelConstraints
    {
        public static void OnModelCreatingAanvraag(ModelBuilder modelBuilder)
        {
            //aanvraag
            modelBuilder.Entity<Aanvraag>()
               .HasKey(a => a.Id);

            modelBuilder.Entity<Aanvraag>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Aanvraag>()
                .Property(a => a.DatumAanvraag)
                .IsRequired();

            modelBuilder.Entity<Aanvraag>()
                .Property(a => a.TypeAanvraag)
                .IsRequired();

            modelBuilder.Entity<Aanvraag>()
                .Property(a => a.GewensteData)
                .IsRequired();

            modelBuilder.Entity<Aanvraag>()
                .Property(a => a.StatusAanvraag)
                .IsRequired();
        }
    }
}
