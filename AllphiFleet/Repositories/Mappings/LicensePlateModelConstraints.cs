using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class LicensePlateModelConstraints
    {
        public static void OnModelCreatingLicensePlate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LicensePlate>()
               .HasKey(l => l.Id);

            modelBuilder.Entity<LicensePlate>()
                .Property(l => l.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<LicensePlate>()
                .Property(l => l.LicensePlateCharacters)
                .IsRequired();
        }
    }
}
