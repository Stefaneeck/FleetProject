using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class RepairModelConstraints
    {
        public static void OnModelCreatingRepair(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Repair>()
               .HasKey(r => r.Id);

            modelBuilder.Entity<Repair>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Repair>()
                .Property(r => r.RepairDate)
                .IsRequired();

            modelBuilder.Entity<Repair>()
                .Property(r => r.DamageDescription)
                .IsRequired();
        }
    }
}
