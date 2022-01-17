using System;

namespace DTO
{
    public class MaintenanceDTO
    {
        public long Id { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public decimal Price { get; set; }
        public string DealerName { get; set; }
        public long InvoiceId { get; set; }
        public long VehicleId { get; set; }
    }
}
