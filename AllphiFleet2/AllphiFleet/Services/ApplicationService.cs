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
    public class ApplicationService : IApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Application> _repository;
        public ApplicationService(IMapper mapper, IDataReadRepository<Application> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public IEnumerable<ApplicationDTO> GetApplications()
        {
            var results = _repository.GetAll()
                .Include(a => a.Vehicle)
                .Include(a => a.Driver);

            return _mapper.Map<IEnumerable<ApplicationDTO>>(results.ToList());
        }

        public ApplicationDTO GetApplication(long id)
        {
            var result = _repository.GetAll()
                .Include(a => a.Vehicle)
                .Include(a => a.Driver)
                .FirstOrDefault(x => x.Id == id);

            return _mapper.Map<ApplicationDTO>(result);
        }
    }
}
