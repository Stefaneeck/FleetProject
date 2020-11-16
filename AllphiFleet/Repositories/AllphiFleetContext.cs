using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.ModelConstraints;

namespace Repositories
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
            ChauffeurModelConstraints.OnModelCreatingChauffeur(modelBuilder);
            AdresModelConstraints.OnModelCreatingAdres(modelBuilder);
            FactuurModelConstraints.OnModelCreatingFactuur(modelBuilder);
            HerstellingModelConstraints.OnModelCreatingHerstelling(modelBuilder);
            NummerplaatModelConstraints.OnModelCreatingNummerplaat(modelBuilder);
            OnderhoudModelConstraints.OnModelCreatingOnderhoud(modelBuilder);
            TankkaartModelConstraints.OnModelCreatingTankkaart(modelBuilder);
            VerzekeringsMaatschappijModelConstraints.OnModelCreatingVerzekeringsMaatschappij(modelBuilder);
            VoertuigModelConstraints.OnModelCreatingVoertuig(modelBuilder);

            //relaties
            ModelConstraintsRelaties.OnModelCreatingMaakRelaties(modelBuilder);
        }
            

            //data invoeren
            //id expliciet meegeven hier, desondanks het auto increment is
            /*
            modelBuilder.Entity<Chauffeur>().HasData(new Chauffeur
            {
                Id = 1,
                Naam = "Bob",
                Voornaam = "Uncle",
                Adres = "Bremptstraat 54",
                GeboorteDatum = new DateTime(1979, 04, 25),
                RijksRegisterNummer = "999-888-7777",
                TypeRijbewijs = RijbewijsTypes.B,
                Actief = true
            }, new Chauffeur
            {
                Id = 2,
                Naam = "Breem",
                Voornaam = "Rik",
                Adres = "Bremptstraat 54",
                GeboorteDatum = new DateTime(1989, 04, 11),
                RijksRegisterNummer = "999-888-1111",
                TypeRijbewijs = RijbewijsTypes.A,
                Actief = true
            }); ;

            
        }
        */
        }
    }
