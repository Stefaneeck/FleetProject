using AllphiFleet.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class ChauffeurContext : DbContext
    {
        public ChauffeurContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Chauffeur> Chauffeurs { get; set; }
        //public DbSet<Account> Accounts { get; set; }

        //data invoeren
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //id expliciet meegeven hier, desondanks het auto increment is
            modelBuilder.Entity<Chauffeur>().HasData(new Chauffeur
            {
                ChauffeurId = 1,
                Naam = "Bob",
                Voornaam = "Uncle",
                Adres = "Bremptstraat 54",
                GeboorteDatum = new DateTime(1979, 04, 25),
                RijksRegisterNummer = "999-888-7777",
                TypeRijbewijs = Chauffeur.RijbewijsTypes.B,
                Actief = true
            }, new Chauffeur
            {
                ChauffeurId = 2,
                Naam = "Breem",
                Voornaam = "Rik",
                Adres = "Bremptstraat 54",
                GeboorteDatum = new DateTime(1989, 04, 11),
                RijksRegisterNummer = "999-888-1111",
                TypeRijbewijs = Chauffeur.RijbewijsTypes.A,
                Actief = true
            });;
        }
    }
}
