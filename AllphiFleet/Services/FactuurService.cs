using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using ReadServices.Interfaces;

namespace ReadServices
{
    public class FactuurService : IFactuurService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Factuur> _repository;
        public FactuurService(IMapper mapper, IDataReadRepository<Factuur> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        //filter nullable maken?
        public IEnumerable<FactuurDTO> GetFacturen(DriverFilter filter)
        {
            //eager loading door include erbij te zetten, standaard haalt hij gerelateerde data niet op (dus geen adressen van chauffeurs bvb)
            var results = _repository.GetAll();

            /*
            
            if (!string.IsNullOrWhiteSpace(filter.Name))
                results = results.Where(x => x.Naam.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.st))
                results = results.Where(x => x.Adres.Contains(filter.st));

            */

            return _mapper.Map<IEnumerable<FactuurDTO>>(results.ToList());
        }

        public FactuurDTO GetFactuur(long id)
        {
            return _mapper.Map<FactuurDTO>(_repository.Get(id));
        }
    }
}
