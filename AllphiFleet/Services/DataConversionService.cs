using AutoMapper;
using DTO;
using Repositories.Models;

namespace Services
{
    public class DataConversionService
    {
        private readonly IMapper _mapper;
        public DataConversionService(IMapper mapper)
        {
            _mapper = mapper;
        }
     
        public ChauffeurDTO[] ChauffeursToDTOs(Chauffeur[] chauffeurs)
        {
            return _mapper.Map<ChauffeurDTO[]>(chauffeurs);
        }
    }
}
