using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories.Mappings
{
    public static class ModelConstraintsRelations
    {
        public static void OnModelCreatingCreateRelations(this ModelBuilder modelBuilder)
        {
            //rel driver address one many
            modelBuilder.Entity<Driver>()
            .HasOne<Address>(d => d.Address)
            .WithMany(a => a.Drivers)
            .HasForeignKey(d => d.AddressId)
            .IsRequired();

            //rel driver fuelcard one many
            modelBuilder.Entity<Driver>()
            .HasOne<FuelCard>(d => d.FuelCard)
            .WithMany(f => f.Drivers)
            .HasForeignKey(d => d.FuelCardId)
            .IsRequired();

            //rel vehicle license plate one many
            modelBuilder.Entity<LicensePlate>()
            .HasOne<Vehicle>(l => l.Vehicle)
            .WithMany(v => v.LicensePlates)
            .HasForeignKey(l => l.VehicleId)
            .IsRequired();

            //rel vehicle maintenance one many
            modelBuilder.Entity<Maintenance>()
            .HasOne<Vehicle>(m => m.Vehicle)
            .WithMany(v => v.Maintenances)
            .HasForeignKey(m => m.VehicleId)
            .IsRequired();

            //rel maintentance invoice one many
            modelBuilder.Entity<Maintenance>()
            .HasOne<Invoice>(m => m.Invoice)
            .WithMany(i => i.MaintenancesOnInvoice)
            .HasForeignKey(m => m.InvoiceId)
            .IsRequired();

            //rel repair insurancecompany one many
            modelBuilder.Entity<Repair>()
            .HasOne<InsuranceCompany>(r => r.InsuranceCompany)
            .WithMany(i => i.Repairs)
            .HasForeignKey(r => r.InsuranceCompanyId)
            .IsRequired();

            //rel application vehicle one many
            modelBuilder.Entity<Application>()
            .HasOne<Vehicle>(a => a.Vehicle)
            .WithMany(v => v.Applications)
            .HasForeignKey(a => a.VehicleId)
            .IsRequired();

        }
    }
}
