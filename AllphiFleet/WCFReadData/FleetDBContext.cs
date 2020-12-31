namespace WCFReadData
{
    using System.Data.Entity;

    public partial class FleetDBContext : DbContext
    {
        public FleetDBContext()
            : base("name=FleetDBModel")
        {
        }

        public virtual DbSet<Aanvraag> Aanvraags { get; set; }
        public virtual DbSet<Adressen> Adressens { get; set; }
        public virtual DbSet<Chauffeur> Chauffeurs { get; set; }
        public virtual DbSet<Factuur> Factuurs { get; set; }
        public virtual DbSet<Herstelling> Herstellings { get; set; }
        public virtual DbSet<Nummerplaat> Nummerplaats { get; set; }
        public virtual DbSet<Onderhoud> Onderhouds { get; set; }
        public virtual DbSet<Tankkaarten> Tankkaartens { get; set; }
        public virtual DbSet<VerzekeringsMaatschappij> VerzekeringsMaatschappijs { get; set; }
        public virtual DbSet<Voertuig> Voertuigs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adressen>()
                .HasMany(e => e.Chauffeurs)
                .WithRequired(e => e.Adressen)
                .HasForeignKey(e => e.AdresId);

            modelBuilder.Entity<Tankkaarten>()
                .HasMany(e => e.Chauffeurs)
                .WithRequired(e => e.Tankkaarten)
                .HasForeignKey(e => e.TankkaartId);
        }
    }
}
