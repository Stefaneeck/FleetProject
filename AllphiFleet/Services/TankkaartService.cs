using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using ReadServices.Interfaces;

namespace ReadServices
{
    public class TankkaartService : ITankkaartService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Tankkaart> _repository;
        public TankkaartService(IMapper mapper, IDataReadRepository<Tankkaart> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        //filter nullable maken?
        public IEnumerable<TankkaartDTO> GetTankkaarten(DriverFilter filter)
        {
            var results = _repository.GetAll();

            return _mapper.Map<IEnumerable<TankkaartDTO>>(results.ToList());
        }

        public TankkaartDTO GetTankkaart(long id)
        {
            return _mapper.Map<TankkaartDTO>(_repository.Get(id));
        }
    }
}
