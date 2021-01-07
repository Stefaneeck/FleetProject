using DTO;
using System.Collections.Generic;

namespace ReadServices.Interfaces
{
    public interface IInvoiceService
    {
        public IEnumerable<InvoiceDTO> GetInvoices();
        public InvoiceDTO GetInvoice(long id);
    }
}
