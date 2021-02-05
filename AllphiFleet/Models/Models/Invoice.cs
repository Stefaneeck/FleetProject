using System.Collections.Generic;

namespace Models
{
    public class Invoice : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual string ClientName { get; set; }
        public virtual ICollection<Maintenance> MaintenancesOnInvoice { get; set; }
        //link to file
        public string InvoiceDocumentPath { get; set; }
    }
}