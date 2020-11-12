using System.Linq;
using Repositories.Models;

namespace Repositories
{
    public class ChauffeurRepository : IDataReadRepository<Chauffeur>
    {
        readonly AllphiFleetContext _fleetContext;
        public ChauffeurRepository(AllphiFleetContext context)
        {
            _fleetContext = context;
        }

        //best iqueryable gebruiken, ienumerable eerder voor in memory data (gaat gegevens eerst lokaal ophalen en dan query'en).
        //iqueryable voert de sql rechtstreeks op de db uit
        public IQueryable<Chauffeur> GetAll()
        {
            return _fleetContext.Chauffeurs;
        }
        public Chauffeur Get(long id)
        {
            return _fleetContext.Chauffeurs
                  .FirstOrDefault(e => e.Id == id);
                    }
    }
}
