using AutoMapper;
using DTO;
using Repositories;
using Repositories.Models;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ChauffeurService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Chauffeur> _repository;
        public ChauffeurService(IMapper mapper, IDataReadRepository<Chauffeur> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
     
        public IEnumerable<ChauffeurDTO> GetChauffeurs(DriverFilter filter)
        {
            //omzetten naar chauffeurDTOs en dan returnen

            var results = _repository.GetAll();
            if (!string.IsNullOrWhiteSpace(filter.Name))
                results = results.Where(x => x.Naam.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.st))
                results = results.Where(x => x.Adres.Contains(filter.st));




            return _mapper.Map<IEnumerable<ChauffeurDTO>>(results);
        }

        public ChauffeurDTO GetChauffeur(long id)
        {
            return _mapper.Map<ChauffeurDTO>(_repository.Get(id));
        }
    }

    public class DriverFilter
    {
        public string Name { get; set; }
        public string st { get; set; }
    }
}
