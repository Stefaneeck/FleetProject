using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using System;

namespace Repositories.ModelConstraints
{
    public static class ChauffeurModelConstraints
    {
        public static void OnModelCreatingChauffeur(this ModelBuilder modelBuilder)
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

            
            //adres en tankkaart kan je hier niet als objecten meegeven, adres en tankkaart apart aanmaken en dan hier enkel verwijzen naar de forgein key id van dat adres

            //data invoeren
            //id expliciet meegeven hier, desondanks het auto increment is
            modelBuilder.Entity<Chauffeur>().HasData(new Chauffeur
            {
                Id = 1,
                Naam = "Bob",
                Voornaam = "Uncle",
                AdresId = 1,

                GeboorteDatum = new DateTime(1979, 04, 25),
                RijksRegisterNummer = "999-888-7777",
                TypeRijbewijs = RijbewijsTypes.B,
                TankkaartId = 1,
                Actief = true
            }, new Chauffeur
            {
                Id = 2,
                Naam = "Breem",
                Voornaam = "Rik",
                AdresId = 2,
                GeboorteDatum = new DateTime(1989, 04, 11),
                RijksRegisterNummer = "999-888-1111",
                TypeRijbewijs = RijbewijsTypes.A,
                TankkaartId = 2,
                Actief = true
            }); ;
            
            

        }
    }
}
