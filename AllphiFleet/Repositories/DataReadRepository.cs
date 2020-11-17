using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    //constraint op TEntity: het moet een klasse en iidentifiable zijn
    public class DataReadRepository<TEntity> : IDataReadRepository<TEntity> where TEntity : class, IIdentifiable
    {
        //moet interface worden
        readonly AllphiFleetContext _fleetContext;
        readonly DbSet<TEntity> table;
        public DataReadRepository(AllphiFleetContext context)
        {
            _fleetContext = context;
            table = _fleetContext.Set<TEntity>();
        }

        //best iqueryable gebruiken, ienumerable eerder voor in memory data (gaat gegevens eerst lokaal ophalen en dan query'en).
        //iqueryable voert de sql rechtstreeks op de db uit
        public IQueryable<TEntity> GetAll()
        {
            return table;
        }

        //ter test, moet weg
        //eager loading door include erbij te zetten, standaard haalt hij gerelateerde data niet op (dus geen adressen van chauffeurs bvb)
        public IQueryable<Chauffeur> GetAllChauffeurs()
        {
            return _fleetContext.Chauffeurs
                   .Include(c => c.Adres)
                   .Include(c => c.Tankkaart);
        }
        public TEntity Get(long id)
        {
            //werkt nu wel, want e zal sowiso een id hebben (interface iidentifiable)
            return table
                  .FirstOrDefault(e => e.Id == id);
        }
    }
}
