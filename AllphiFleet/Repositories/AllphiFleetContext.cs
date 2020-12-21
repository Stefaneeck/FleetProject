using Microsoft.EntityFrameworkCore;
using Models;
using Models.Auth;
using ReadRepositories.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ReadRepositories
{
    public class AllphiFleetContext : IdentityDbContext<User>
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
            //identity
            base.OnModelCreating(modelBuilder);

            modelBuilder.OnModelCreatingChauffeur();
            modelBuilder.OnModelCreatingAdres();
            modelBuilder.OnModelCreatingFactuur();
            modelBuilder.OnModelCreatingHerstelling();
            modelBuilder.OnModelCreatingNummerplaat();
            modelBuilder.OnModelCreatingOnderhoud();
            modelBuilder.OnModelCreatingTankkaart();
            modelBuilder.OnModelCreatingVerzekeringsMaatschappij();
            modelBuilder.OnModelCreatingVoertuig();
            modelBuilder.OnModelCreatingMaakRelaties();
        }
    }
}
