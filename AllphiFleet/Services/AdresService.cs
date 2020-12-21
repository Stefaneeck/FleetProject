using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using ReadServices.Interfaces;

namespace ReadServices
{
    public class AdresService : IAdresService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Adres> _repository;
        public AdresService(IMapper mapper, IDataReadRepository<Adres> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<AdresDTO> GetAdressen(DriverFilter filter)
        {
            var results = _repository.GetAll();
            return _mapper.Map<IEnumerable<AdresDTO>>(results.ToList());
        }

        public AdresDTO GetAdres(long id)
        {
            return _mapper.Map<AdresDTO>(_repository.Get(id));
        }
    }
}
