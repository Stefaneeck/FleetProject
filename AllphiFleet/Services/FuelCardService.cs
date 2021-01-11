using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using ReadServices.Interfaces;

namespace ReadServices
{
    public class FuelCardService : IFuelCardService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<FuelCard> _repository;
        public FuelCardService(IMapper mapper, IDataReadRepository<FuelCard> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<FuelCardDTO> GetFuelCards()
        {
            var results = _repository.GetAll();
            return _mapper.Map<IEnumerable<FuelCardDTO>>(results.ToList());
        }

        public FuelCardDTO GetFuelCard(long id)
        {
            return _mapper.Map<FuelCardDTO>(_repository.Get(id));
        }
    }
}
