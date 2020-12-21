using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class OnderhoudModelConstraints
    {
        public static void OnModelCreatingOnderhoud(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Onderhoud>()
               .HasKey(o => o.Id);

            modelBuilder.Entity<Onderhoud>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Onderhoud>()
                .Property(o => o.DatumOnderhoud)
                .IsRequired();

            modelBuilder.Entity<Onderhoud>()
                .Property(o => o.Prijs)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Onderhoud>()
                .Property(o => o.Prijs)
                .IsRequired();

            modelBuilder.Entity<Onderhoud>()
                .Property(o => o.Garage)
                .IsRequired();

            //navigation properties kunnen niet via fluent api property geconfigureerd worden
            //is required wordt dan gezet bij de relatie hasone withmany hasforeignkey isrequired
            /*
            modelBuilder.Entity<Onderhoud>()
                .Property(o => o.Factuur)
                .IsRequired();

            */
        }
    }
}
