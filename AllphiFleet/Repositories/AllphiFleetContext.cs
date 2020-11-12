using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;

namespace Repositories
{
    public class AllphiFleetContext : DbContext
    {
        public AllphiFleetContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Chauffeur> Chauffeurs { get; set; }
        //public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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

            modelBuilder.Entity<Chauffeur>()
                .Property(c => c.Adres)
                .IsRequired();

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

            
        }
    }
}
