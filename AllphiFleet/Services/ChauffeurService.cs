using AutoMapper;
using DTO;
using Repositories;
using Repositories.Models;
using System.Collections.Generic;

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
     
        public IEnumerable<ChauffeurDTO> GetChauffeurs()
        {
            //omzetten naar chauffeurDTOs en dan returnen
            return _mapper.Map<IEnumerable<ChauffeurDTO>>(_repository.GetAll());
        }

        public ChauffeurDTO GetChauffeur(long id)
        {
            return _mapper.Map<ChauffeurDTO>(_repository.Get(id));
        }
    }
}
