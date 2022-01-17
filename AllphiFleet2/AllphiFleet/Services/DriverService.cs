using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReadServices.Interfaces;
using System;

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

        public long GetDriverIdByEmail(string email)
        {
            //default is empty (to handle null error when there is no record found).
            var driver = _repository.GetAll().Where(driver => driver.Email.ToLower().Trim() == email.ToLower().Trim()).AsEnumerable().DefaultIfEmpty(new Driver()).First();

            #region tryCatchAlternative
            /*
            long driverId;
            try
            {
                driverId = _repository.GetAll().FirstOrDefault(driver => driver.Email.ToLower() == email.ToLower()).Id;
            }
            catch(Exception e)
            {
                driverId = 0;
            }

            return driverId;
            */
            #endregion

            return driver.Id;

            #region commentGetDriverIdByEmail
            /*
            not easily possible to filter on email in generic repository, so filtered here
            todo: check if 0 or multiple then something went wrong

            same as
            var result = _repository.Drivers.Where(x => x.Email.ToLower() == email.ToLower()).First().Id;
            */
            #endregion
        }

        public long GetDriverIdBySocSecNr(string socSecNr)
        {
            var driver = _repository.GetAll().Where(driver => driver.SocSecNr.ToLower() == socSecNr.ToLower()).AsEnumerable().DefaultIfEmpty(new Driver()).First();

            return driver.Id;
        }
    }

}
