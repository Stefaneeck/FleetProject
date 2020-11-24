using AutoMapper;
using DTO;
using Repositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using Services.Interfaces;

namespace Services
{
    public class AdresService : IAdresService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Adres> _repository;
        public AdresService(IMapper mapper, IDataReadRepository<Adres> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        //filter nullable maken?
        public IEnumerable<AdresDTO> GetAdressen(DriverFilter filter)
        {
            //eager loading door include erbij te zetten, standaard haalt hij gerelateerde data niet op (dus geen adressen van chauffeurs bvb)
            var results = _repository.GetAll();

            /*
            
            if (!string.IsNullOrWhiteSpace(filter.Name))
                results = results.Where(x => x.Naam.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.st))
                results = results.Where(x => x.Adres.Contains(filter.st));

            */

            return _mapper.Map<IEnumerable<AdresDTO>>(results.ToList());
        }

        public AdresDTO GetAdres(long id)
        {
            return _mapper.Map<AdresDTO>(_repository.Get(id));
        }
    }
}
