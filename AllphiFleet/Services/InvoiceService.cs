using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using ReadServices.Interfaces;

namespace ReadServices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Invoice> _repository;
        public InvoiceService(IMapper mapper, IDataReadRepository<Invoice> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<InvoiceDTO> GetInvoices()
        {
            var results = _repository.GetAll();
            return _mapper.Map<IEnumerable<InvoiceDTO>>(results.ToList());
        }

        public InvoiceDTO GetInvoice(long id)
        {
            return _mapper.Map<InvoiceDTO>(_repository.Get(id));
        }
    }
}
