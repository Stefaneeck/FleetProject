using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class VehicleModelConstraints
    {
        public static void OnModelCreatingVehicle(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.FuelType)
                .IsRequired();

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.VehicleType)
                .IsRequired();

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Mileage)
                .IsRequired();

            modelBuilder.Entity<Vehicle>()
               .Property(v => v.ChassisNr)
               .IsRequired();

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.ActiveLicensePlateId)
                .IsRequired();
        }
    }
}
