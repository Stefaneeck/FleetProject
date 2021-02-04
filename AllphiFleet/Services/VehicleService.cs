using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using ReadServices.Interfaces;
using DTO.MileageHistory;

namespace ReadServices
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Vehicle> _vehicleRepository;
        private readonly IDataReadRepository<MileageHistory> _mileageHistoryRepository;

        public VehicleService(IMapper mapper, IDataReadRepository<Vehicle> vehicleRepository, IDataReadRepository<MileageHistory> mileageHistoryRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _mileageHistoryRepository = mileageHistoryRepository;
        }

        public IEnumerable<VehicleDTO> GetVehicles()
        {
            var results = _vehicleRepository.GetAll();
            return _mapper.Map<IEnumerable<VehicleDTO>>(results.ToList());
        }

        public VehicleDTO GetVehicle(long id)
        {
            return _mapper.Map<VehicleDTO>(_vehicleRepository.Get(id));
        }

        public IEnumerable<MileageHistoryDTO> GetVehicleMileageHistory(long vehicleId)
        {
            return _mapper.Map<IEnumerable<MileageHistoryDTO>>(_mileageHistoryRepository.GetHistory(vehicleId).ToList());
        }
    }
}
