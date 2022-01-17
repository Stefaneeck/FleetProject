using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class AddressModelConstraints
    {
        public static void OnModelCreatingAddress(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                    .HasKey(a => a.Id);

            modelBuilder.Entity<Address>()
                    .Property(a => a.Id)
                    .ValueGeneratedOnAdd();

            modelBuilder.Entity<Address>()
                    .Property(a => a.Street)
                    .IsRequired();

            modelBuilder.Entity<Address>()
                    .Property(a => a.Number)
                    .IsRequired();

            modelBuilder.Entity<Address>()
                    .Property(a => a.City)
                    .IsRequired();

            modelBuilder.Entity<Address>()
                    .Property(a => a.Zipcode)
                    .IsRequired();

        }
    }
}
