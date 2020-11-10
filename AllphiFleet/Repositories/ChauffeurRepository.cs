using System.Collections.Generic;
using System.Linq;
using Repositories.Models;

namespace Repositories
{
    public class ChauffeurRepository : IDataReadRepository<Chauffeur>
    {
        readonly ChauffeurContext _chauffeurContext;
        public ChauffeurRepository(ChauffeurContext context)
        {
            _chauffeurContext = context;
        }

        //best iqueryable gebruiken, ienumerable eerder voor in memory data (gaat gegevens eerst lokaal ophalen en dan query'en).
        //iqueryable voert de sql rechtstreeks op de db uit
        public IEnumerable<Chauffeur> GetAll()
        {
            return _chauffeurContext.Chauffeurs.ToList();
        }
        public Chauffeur Get(long id)
        {
            return _chauffeurContext.Chauffeurs
                  .FirstOrDefault(e => e.ChauffeurId == id);
                    }
    }
}
