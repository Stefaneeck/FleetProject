using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class MaintenanceModelConstraints
    {
        public static void OnModelCreatingMaintenance(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Maintenance>()
               .HasKey(m => m.Id);

            modelBuilder.Entity<Maintenance>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Maintenance>()
                .Property(m => m.MaintenanceDate)
                .IsRequired();

            modelBuilder.Entity<Maintenance>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Maintenance>()
                .Property(m => m.Price)
                .IsRequired();

            modelBuilder.Entity<Maintenance>()
                .Property(m => m.DealerName)
                .IsRequired();

            //navigation properties cant be configured via fluent api property
            //is required placed at relation hasone withmany hasforeignkey isrequired
            /*
            modelBuilder.Entity<Maintentance>()
                .Property(m => m.Invoice)
                .IsRequired();

            */
        }
    }
}
