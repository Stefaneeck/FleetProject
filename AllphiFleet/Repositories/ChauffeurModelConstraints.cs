using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Repositories
{
    public class ChauffeurModelConstraints
    {
        public static void OnModelCreatingChauffeur(ModelBuilder modelBuilder)
        {
            //instellingen voor de tabel in de databank
            //werken met fluent api manier in plaats van annotations in model klasse zelf, zodat we geen annotions moeten gebruiken en de klassen daar als DTO's kunnen gebruiken
            
            modelBuilder.Entity<Chauffeur>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Chauffeur>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Chauffeur>()
                .Property(c => c.Naam)
                .IsRequired();

            modelBuilder.Entity<Chauffeur>()
                .Property(c => c.Voornaam)
                .IsRequired();

            //navigation properties kunnen niet via fluent api property geconfigureerd worden
            //is required wordt dan gezet bij de relatie hasone withmany hasforeignkey isrequired
            /*
            modelBuilder.Entity<Chauffeur>()
                .Property(c => c.Adres)
                .IsRequired();
            */

            modelBuilder.Entity<Chauffeur>()
                .Property(c => c.GeboorteDatum)
                .IsRequired();

            modelBuilder.Entity<Chauffeur>()
                .Property(c => c.RijksRegisterNummer)
                .IsRequired();

            modelBuilder.Entity<Chauffeur>()
                .Property(c => c.TypeRijbewijs)
                .IsRequired();

            modelBuilder.Entity<Chauffeur>()
                .Property(c => c.Actief)
                .IsRequired();

            //rel chauffeur adres one many
            modelBuilder.Entity<Chauffeur>()
            .HasOne<Adres>(c => c.Adres)
            .WithMany(a => a.Chauffeurs)
            .HasForeignKey(c => c.AdresId)
            .IsRequired();

            //adres

            modelBuilder.Entity<Adres>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Adres>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Adres>()
                .Property(a => a.Straat)
                .IsRequired();

            modelBuilder.Entity<Adres>()
                .Property(a => a.Nummer)
                .IsRequired();

            modelBuilder.Entity<Adres>()
                .Property(a => a.Stad)
                .IsRequired();

            modelBuilder.Entity<Adres>()
                .Property(a => a.Postcode)
                .IsRequired();

            //tankkaart

            modelBuilder.Entity<Tankkaart>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Tankkaart>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Tankkaart>()
                .Property(c => c.Kaartnummer)
                .IsRequired();

            modelBuilder.Entity<Tankkaart>()
                .Property(c => c.GeldigheidsDatum)
                .IsRequired();

            modelBuilder.Entity<Tankkaart>()
                .Property(c => c.Pincode)
                .IsRequired();

            modelBuilder.Entity<Tankkaart>()
                .Property(c => c.AuthType)
                .IsRequired();

            modelBuilder.Entity<Tankkaart>()
                .Property(c => c.Opties)
                .IsRequired();

            //rel chauffeur tankkaart one many
            modelBuilder.Entity<Chauffeur>()
            .HasOne<Tankkaart>(c => c.Tankkaart)
            .WithMany(t => t.Chauffeurs)
            .HasForeignKey(c => c.TankkaartId)
            .IsRequired();

            //voertuig

            modelBuilder.Entity<Voertuig>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Voertuig>()
                .Property(v => v.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Voertuig>()
                .Property(v => v.TypeBrandStof)
                .IsRequired();

            modelBuilder.Entity<Voertuig>()
                .Property(v => v.TypeWagen)
                .IsRequired();

            modelBuilder.Entity<Voertuig>()
                .Property(v => v.KilometerStand)
                .IsRequired();

            //nummerplaat
            modelBuilder.Entity<Nummerplaat>()
               .HasKey(n => n.Id);

            modelBuilder.Entity<Nummerplaat>()
                .Property(n => n.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Nummerplaat>()
                .Property(n => n.NummerPlaatTekens)
                .IsRequired();


            //rel voertuig nummerplaat one many
            modelBuilder.Entity<Nummerplaat>()
            .HasOne<Voertuig>(n => n.Voertuig)
            .WithMany(v => v.Nummerplaten)
            .HasForeignKey(n => n.VoertuigId)
            .IsRequired();

            //onderhoud
            modelBuilder.Entity<Onderhoud>()
               .HasKey(o => o.Id);

            modelBuilder.Entity<Onderhoud>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Onderhoud>()
                .Property(o => o.DatumOnderhoud)
                .IsRequired();

            modelBuilder.Entity<Onderhoud>()
                .Property(o => o.Prijs)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Onderhoud>()
                .Property(o => o.Prijs)
                .IsRequired();

            modelBuilder.Entity<Onderhoud>()
                .Property(o => o.Garage)
                .IsRequired();

            //navigation properties kunnen niet via fluent api property geconfigureerd worden
            //is required wordt dan gezet bij de relatie hasone withmany hasforeignkey isrequired
            /*
            modelBuilder.Entity<Onderhoud>()
                .Property(o => o.Factuur)
                .IsRequired();

            */

            //rel voertuig onderhoud one many
            modelBuilder.Entity<Onderhoud>()
            .HasOne<Voertuig>(n => n.Voertuig)
            .WithMany(v => v.OnderhoudsBeurten)
            .HasForeignKey(o => o.VoertuigId)
            .IsRequired();

            //factuur
            modelBuilder.Entity<Factuur>()
               .HasKey(f => f.Id);

            modelBuilder.Entity<Factuur>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Factuur>()
                .Property(f => f.NaamGefactureerde)
                .IsRequired();

            //rel onderhoud factuur one many
            modelBuilder.Entity<Onderhoud>()
            .HasOne<Factuur>(o => o.Factuur)
            .WithMany(f => f.OnderhoudenOpFactuur)
            .HasForeignKey(o => o.FactuurId)
            .IsRequired();


            /*
            //data invoeren
            //id expliciet meegeven hier, desondanks het auto increment is
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
            */

        }
    }
}
