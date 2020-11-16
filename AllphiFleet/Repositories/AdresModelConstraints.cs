﻿using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class AdresModelConstraints
    {
        public static void OnModelCreatingAdres(ModelBuilder modelBuilder)
        {
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

        }
    }
}
