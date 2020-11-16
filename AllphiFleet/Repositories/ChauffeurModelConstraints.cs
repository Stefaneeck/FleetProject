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
