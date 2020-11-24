using AutoMapper;
using DTO;
using Repositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services
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

        //filter nullable maken?
        public IEnumerable<AanvraagDTO> GetAanvragen(DriverFilter filter)
        {
            //eager loading door include erbij te zetten, standaard haalt hij gerelateerde data niet op (dus geen adressen van chauffeurs bvb)
            var results = _repository.GetAll()
                .Include(a => a.Voertuig);


            /*
            
            if (!string.IsNullOrWhiteSpace(filter.Name))
                results = results.Where(x => x.Naam.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.st))
                results = results.Where(x => x.Adres.Contains(filter.st));

            */

            return _mapper.Map<IEnumerable<AanvraagDTO>>(results.ToList());
        }

        public AanvraagDTO GetAanvraag(long id)
        {
            return _mapper.Map<AanvraagDTO>(_repository.Get(id));
        }
    }
}
