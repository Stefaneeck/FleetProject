using Microsoft.EntityFrameworkCore;
using Models;
using Models.Auth;
using ReadRepositories.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ReadRepositories
{
    public class AllphiFleetContext : IdentityDbContext<User>
    {
        public AllphiFleetContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<FuelCard> FuelCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //identity
            base.OnModelCreating(modelBuilder);

            modelBuilder.OnModelCreatingDriver();
            modelBuilder.OnModelCreatingAddress();
            modelBuilder.OnModelCreatingInvoice();
            modelBuilder.OnModelCreatingRepair();
            modelBuilder.OnModelCreatingLicensePlate();
            modelBuilder.OnModelCreatingMaintenance();
            modelBuilder.OnModelCreatingFuelCard();
            modelBuilder.OnModelCreatingInsuranceCompany();
            modelBuilder.OnModelCreatingVehicle();
            modelBuilder.OnModelCreatingCreateRelations();
        }
    }
}
