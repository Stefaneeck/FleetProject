using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using ReadServices.Interfaces;
using DTO.MileageHistory;
using DTO.LicensePlate;

namespace ReadServices
{
    public class LicensePlateService : ILicensePlateService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<LicensePlate> _licensePlateRepository;

        public LicensePlateService(IMapper mapper, IDataReadRepository<LicensePlate> licensePlateRepository)
        {
            _mapper = mapper;
            _licensePlateRepository = licensePlateRepository;
        }

        public IEnumerable<LicensePlateDTO> GetLicensePlates()
        {
            var results = _licensePlateRepository.GetAll();
            return _mapper.Map<IEnumerable<LicensePlateDTO>>(results.ToList());
        }

        public LicensePlateDTO GetLicensePlate(long id)
        {
            return _mapper.Map<LicensePlateDTO>(_licensePlateRepository.Get(id));
        }
    }
}
