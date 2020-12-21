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

        public IEnumerable<FactuurDTO> GetFacturen(DriverFilter filter)
        {
            var results = _repository.GetAll();
            return _mapper.Map<IEnumerable<FactuurDTO>>(results.ToList());
        }

        public FactuurDTO GetFactuur(long id)
        {
            return _mapper.Map<FactuurDTO>(_repository.Get(id));
        }
    }
}
