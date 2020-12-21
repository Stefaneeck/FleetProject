using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using System;

namespace ReadRepositories.Mappings
{
    public static class ChauffeurModelConstraints
    {
        public static void OnModelCreatingChauffeur(this ModelBuilder modelBuilder)
        {
            //settings for database table
            //fluent api way instead of annotations in domain classes. Makes it easier to use the domain classes as DTO as well.

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
        }
    }
}
