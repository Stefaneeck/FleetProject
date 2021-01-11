using System;

namespace Models
{
    public class Maintenance : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual DateTime MaintenanceDate { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string DealerName { get; set; }

        //rel factuur
        public virtual long InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

        //rel voertuig
        public virtual long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
