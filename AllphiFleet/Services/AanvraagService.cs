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
    public class AanvraagService : IAanvraagService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Aanvraag> _repository;
        public AanvraagService(IMapper mapper, IDataReadRepository<Aanvraag> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public IEnumerable<AanvraagDTO> GetAanvragen(DriverFilter filter)
        {
            var results = _repository.GetAll()
                .Include(a => a.Voertuig);

            return _mapper.Map<IEnumerable<AanvraagDTO>>(results.ToList());
        }

        public AanvraagDTO GetAanvraag(long id)
        {
            return _mapper.Map<AanvraagDTO>(_repository.Get(id));
        }
    }
}
