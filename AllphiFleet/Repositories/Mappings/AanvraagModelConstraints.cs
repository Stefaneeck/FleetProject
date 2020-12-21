﻿using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class AanvraagModelConstraints
    {
        public static void OnModelCreatingAanvraag(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aanvraag>()
               .HasKey(a => a.Id);

            modelBuilder.Entity<Aanvraag>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Aanvraag>()
                .Property(a => a.DatumAanvraag)
                .IsRequired();

            modelBuilder.Entity<Aanvraag>()
                .Property(a => a.TypeAanvraag)
                .IsRequired();

            modelBuilder.Entity<Aanvraag>()
                .Property(a => a.GewensteData)
                .IsRequired();

            modelBuilder.Entity<Aanvraag>()
                .Property(a => a.StatusAanvraag)
                .IsRequired();
        }
    }
}
