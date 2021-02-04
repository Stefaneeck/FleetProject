using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ReadRepositories
{
    public class DataReadRepository<TEntity> : IDataReadRepository<TEntity> where TEntity : class, IIdentifiable
    {
        //todo: make interface
        readonly AllphiFleetContext _fleetContext;
        readonly DbSet<TEntity> table;
        public DataReadRepository(AllphiFleetContext context)
        {
            _fleetContext = context;
            table = _fleetContext.Set<TEntity>();
        }

        //iqueriable best choice here, executes sql directly on db.
        //ienumerable for in memory data (will transfer data locally and query after).

        public IQueryable<TEntity> GetAll()
        {
            return table;
        }

        public TEntity Get(long id)
        {

            return table.FirstOrDefault(e => e.Id == id);
        }

        public IQueryable<MileageHistory> GetHistory(long vehicleId)
        {
            //ok to create concrete table here?

            var mileageHistoryTable = _fleetContext.Set<MileageHistory>();
            return mileageHistoryTable.Where(e => e.VehicleId == vehicleId);
        }
    }
}
