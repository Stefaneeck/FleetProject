using DTO;
using System.Collections.Generic;

namespace ReadServices.Interfaces
{
    public interface IChauffeurService
    {
        public IEnumerable<ChauffeurDTO> GetChauffeurs(DriverFilter filter);
        public ChauffeurDTO GetChauffeur(long id);
    }
}
