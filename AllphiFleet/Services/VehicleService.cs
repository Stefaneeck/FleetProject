using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using ReadServices.Interfaces;

namespace ReadServices
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Vehicle> _repository;
        public VehicleService(IMapper mapper, IDataReadRepository<Vehicle> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<VehicleDTO> GetVehicles()
        {
            var results = _repository.GetAll();
            return _mapper.Map<IEnumerable<VehicleDTO>>(results.ToList());
        }

        public VehicleDTO GetVehicle(long id)
        {
            return _mapper.Map<VehicleDTO>(_repository.Get(id));
        }
    }
}
