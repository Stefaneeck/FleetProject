using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class TankkaartModelConstraints
    {
        public static void OnModelCreatingTankkaart(this ModelBuilder modelBuilder)
        {
            //tankkaart

            modelBuilder.Entity<Tankkaart>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Tankkaart>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Tankkaart>()
                .Property(c => c.Kaartnummer)
                .IsRequired();

            modelBuilder.Entity<Tankkaart>()
                .Property(c => c.GeldigheidsDatum)
                .IsRequired();

            modelBuilder.Entity<Tankkaart>()
                .Property(c => c.Pincode)
                .IsRequired();

            modelBuilder.Entity<Tankkaart>()
                .Property(c => c.AuthType)
                .IsRequired();

            modelBuilder.Entity<Tankkaart>()
                .Property(c => c.Opties)
                .IsRequired();
        }
    }
}
