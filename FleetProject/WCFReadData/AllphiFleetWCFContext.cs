namespace WCFReadData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AllphiFleetWCFContext : DbContext
    {
        public AllphiFleetWCFContext()
            : base("name=AllphiFleet")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<FuelCard> FuelCards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(e => e.Drivers)
                .WithRequired(e => e.Address)
                .HasForeignKey(e => e.AddressId);

            modelBuilder.Entity<FuelCard>()
                .HasMany(e => e.Drivers)
                .WithRequired(e => e.FuelCard)
                .HasForeignKey(e => e.FuelCardId);
        }
    }
}
