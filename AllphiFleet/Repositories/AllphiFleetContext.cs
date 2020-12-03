using Microsoft.EntityFrameworkCore;
using Models;
using ReadRepositories.Mappings;

namespace ReadRepositories
{
    public class AllphiFleetContext : DbContext
    {
        public AllphiFleetContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Chauffeur> Chauffeurs { get; set; }
        public DbSet<Adres> Adressen { get; set; }
        public DbSet<Tankkaart> Tankkaarten { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ChauffeurModelConstraints.OnModelCreatingChauffeur(modelBuilder);
            modelBuilder.OnModelCreatingChauffeur();
            modelBuilder.OnModelCreatingAdres();
            modelBuilder.OnModelCreatingFactuur();
            modelBuilder.OnModelCreatingHerstelling();
            modelBuilder.OnModelCreatingNummerplaat();
            modelBuilder.OnModelCreatingOnderhoud();
            modelBuilder.OnModelCreatingTankkaart();
            modelBuilder.OnModelCreatingVerzekeringsMaatschappij();
            modelBuilder.OnModelCreatingVoertuig();

            //relaties nog over te zetten
            modelBuilder.OnModelCreatingMaakRelaties();
        }
    }
}
