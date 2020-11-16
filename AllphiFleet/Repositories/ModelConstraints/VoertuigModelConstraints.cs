using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories.ModelConstraints
{
    public class VoertuigModelConstraints
    {
        public static void OnModelCreatingVoertuig(ModelBuilder modelBuilder)
        {
            //voertuig

            modelBuilder.Entity<Voertuig>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Voertuig>()
                .Property(v => v.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Voertuig>()
                .Property(v => v.TypeBrandStof)
                .IsRequired();

            modelBuilder.Entity<Voertuig>()
                .Property(v => v.TypeWagen)
                .IsRequired();

            modelBuilder.Entity<Voertuig>()
                .Property(v => v.KilometerStand)
                .IsRequired();
        }
    }
}
