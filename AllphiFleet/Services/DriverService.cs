using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReadServices.Interfaces;

namespace ReadServices
{
    public class DriverService : IDriverService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Driver> _repository;
        public DriverService(IMapper mapper, IDataReadRepository<Driver> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
     
        public IEnumerable<DriverDTO> GetDrivers()
        {
            //eager loading by adding include, by default he doesnt fetch related data (so no addresses of drivers for instance)
            var results = _repository.GetAll()
                .Include(d => d.Address)
                .Include(d => d.FuelCard);

            //tolist = not working with abstract query anymore, but force to work with concrete data
            return _mapper.Map<IEnumerable<DriverDTO>>(results.ToList());

        }

        public DriverDTO GetDriver(long id)
        {
            var result = _repository.GetAll()
                .Include(d => d.Address)
                .Include(d => d.FuelCard)
                .FirstOrDefault(x => x.Id == id);

            return _mapper.Map<DriverDTO>(result);

            #region commentInclude
            //cant do include on domain object, only on iquerable
            /*
            return _mapper.Map<DriverDTO>(_repository.Get(id)
                .Include(c => c.Address)
                .Include(c => c.FuelCard));
            */
            #endregion
        }
    }

}
