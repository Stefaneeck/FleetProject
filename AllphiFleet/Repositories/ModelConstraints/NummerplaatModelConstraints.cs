using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories.ModelConstraints
{
    public static class NummerplaatModelConstraints
    {
        public static void OnModelCreatingNummerplaat(this ModelBuilder modelBuilder)
        {
            //nummerplaat
            modelBuilder.Entity<Nummerplaat>()
               .HasKey(n => n.Id);

            modelBuilder.Entity<Nummerplaat>()
                .Property(n => n.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Nummerplaat>()
                .Property(n => n.NummerPlaatTekens)
                .IsRequired();
        }
    }
}
