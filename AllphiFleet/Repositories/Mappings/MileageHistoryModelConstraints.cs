using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadRepositories.Mappings
{
    public static class MileageHistoryModelConstraints
    {
        public static void OnModelCreatingMileageHistory(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MileageHistory>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<MileageHistory>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MileageHistory>()
                .Property(m => m.VehicleId)
                .IsRequired();

            modelBuilder.Entity<MileageHistory>()
                .Property(m => m.Mileage)
                .IsRequired();
        }
    }
}
