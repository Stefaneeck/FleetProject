using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class VerzekeringsMaatschappijModelConstraints
    {
        public static void OnModelCreatingVerzekeringsMaatschappij(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VerzekeringsMaatschappij>()
               .HasKey(v => v.Id);

            modelBuilder.Entity<VerzekeringsMaatschappij>()
                .Property(v => v.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<VerzekeringsMaatschappij>()
                .Property(v => v.ReferentieNrVerzekeringsMaatschappij)
                .IsRequired();
        }
    }
}
