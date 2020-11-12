

using DTO;
using System.Collections.Generic;

namespace Services
{
    public interface IChauffeurService
    {
        public IEnumerable<ChauffeurDTO> GetChauffeurs(DriverFilter filter);

        public ChauffeurDTO GetChauffeur(long id);
    }
}
