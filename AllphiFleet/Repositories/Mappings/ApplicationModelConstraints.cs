using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class ApplicationModelConstraints
    {
        public static void OnModelCreatingApplication(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
               .HasKey(a => a.Id);

            modelBuilder.Entity<Application>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Application>()
                .Property(a => a.ApplicationDate)
                .IsRequired();

            modelBuilder.Entity<Application>()
                .Property(a => a.ApplicationType)
                .IsRequired();

            modelBuilder.Entity<Application>()
                .Property(a => a.PossibleDates)
                .IsRequired();

            modelBuilder.Entity<Application>()
                .Property(a => a.ApplicationStatus)
                .IsRequired();
        }
    }
}
