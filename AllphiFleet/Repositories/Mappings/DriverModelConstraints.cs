using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using System;

namespace ReadRepositories.Mappings
{
    public static class DriverModelConstraints
    {
        public static void OnModelCreatingDriver(this ModelBuilder modelBuilder)
        {
            //settings for database table
            //fluent api way instead of annotations in domain classes. Makes it easier to use the domain classes as DTO as well.

            modelBuilder.Entity<Driver>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Driver>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Driver>()
                .Property(d => d.Name)
                .IsRequired();

            modelBuilder.Entity<Driver>()
                .Property(d => d.FirstName)
                .IsRequired();

            //navigation properties can't be set via fluent api property, is required is placed at the relation definition (hasone withmany hasforeignkey isrequired)
            /*
            modelBuilder.Entity<Chauffeur>()
                .Property(c => c.Adres)
                .IsRequired();
            */

            modelBuilder.Entity<Driver>()
                .Property(d => d.BirthDate)
                .IsRequired();

            modelBuilder.Entity<Driver>()
                .Property(d => d.SocSecNr)
                .IsRequired();

            modelBuilder.Entity<Driver>()
                .Property(d => d.DriverLicenseType)
                .IsRequired();

            modelBuilder.Entity<Driver>()
                .Property(d => d.Active)
                .IsRequired();
        }
    }
}
