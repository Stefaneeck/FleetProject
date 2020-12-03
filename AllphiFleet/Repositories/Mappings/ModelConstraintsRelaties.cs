using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class ModelConstraintsRelaties
    {
        public static void OnModelCreatingMaakRelaties(this ModelBuilder modelBuilder)
        {
            //rel chauffeur adres one many
            modelBuilder.Entity<Chauffeur>()
            .HasOne<Adres>(c => c.Adres)
            .WithMany(a => a.Chauffeurs)
            .HasForeignKey(c => c.AdresId)
            .IsRequired();

            //rel chauffeur tankkaart one many
            modelBuilder.Entity<Chauffeur>()
            .HasOne<Tankkaart>(c => c.Tankkaart)
            .WithMany(t => t.Chauffeurs)
            .HasForeignKey(c => c.TankkaartId)
            .IsRequired();

            //rel voertuig nummerplaat one many
            modelBuilder.Entity<Nummerplaat>()
            .HasOne<Voertuig>(n => n.Voertuig)
            .WithMany(v => v.Nummerplaten)
            .HasForeignKey(n => n.VoertuigId)
            .IsRequired();

            //rel voertuig onderhoud one many
            modelBuilder.Entity<Onderhoud>()
            .HasOne<Voertuig>(n => n.Voertuig)
            .WithMany(v => v.OnderhoudsBeurten)
            .HasForeignKey(o => o.VoertuigId)
            .IsRequired();

            //rel onderhoud factuur one many
            modelBuilder.Entity<Onderhoud>()
            .HasOne<Factuur>(o => o.Factuur)
            .WithMany(f => f.OnderhoudenOpFactuur)
            .HasForeignKey(o => o.FactuurId)
            .IsRequired();

            //rel herstelling verzekeringsmaatschappij one many
            modelBuilder.Entity<Herstelling>()
            .HasOne<VerzekeringsMaatschappij>(h => h.VerzekeringsMaatschappij)
            .WithMany(v => v.Herstellingen)
            .HasForeignKey(h => h.VerzekeringsMaatschappijId)
            .IsRequired();

            //rel aanvraag voertuig one many
            modelBuilder.Entity<Aanvraag>()
            .HasOne<Voertuig>(a => a.Voertuig)
            .WithMany(v => v.Aanvragen)
            .HasForeignKey(a => a.VoertuigId)
            .IsRequired();

        }
    }
}
