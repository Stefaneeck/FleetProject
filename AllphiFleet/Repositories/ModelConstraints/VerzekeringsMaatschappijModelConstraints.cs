using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories.ModelConstraints
{
    public static class VerzekeringsMaatschappijModelConstraints
    {
        public static void OnModelCreatingVerzekeringsMaatschappij(this ModelBuilder modelBuilder)
        {
            //verzekeringsmaatschapij
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
