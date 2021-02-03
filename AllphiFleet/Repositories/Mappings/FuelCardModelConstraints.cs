using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class FuelCardModelConstraints
    {
        public static void OnModelCreatingFuelCard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuelCard>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<FuelCard>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<FuelCard>()
                .Property(f => f.CardNumber)
                .IsRequired();

            modelBuilder.Entity<FuelCard>()
                .HasIndex(f => f.CardNumber)
                .IsUnique();

            modelBuilder.Entity<FuelCard>()
                .Property(f => f.ValidUntilDate)
                .IsRequired();

            modelBuilder.Entity<FuelCard>()
                .Property(f => f.Pincode)
                .IsRequired();

            modelBuilder.Entity<FuelCard>()
                .Property(f => f.AuthType)
                .IsRequired();

            modelBuilder.Entity<FuelCard>()
                .Property(f => f.Options)
                .IsRequired();

            modelBuilder.Entity<FuelCard>()
                .Property(f => f.Active)
                .IsRequired();
        }
    }
}
