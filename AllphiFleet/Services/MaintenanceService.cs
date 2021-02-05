using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using ReadServices.Interfaces;

namespace ReadServices
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Maintenance> _repository;
        public MaintenanceService(IMapper mapper, IDataReadRepository<Maintenance> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<MaintenanceDTO> GetMaintenances()
        {
            var results = _repository.GetAll();
            return _mapper.Map<IEnumerable<MaintenanceDTO>>(results.ToList());
        }

        public MaintenanceDTO GetMaintenance(long id)
        {
            return _mapper.Map<MaintenanceDTO>(_repository.Get(id));
        }
    }
}
