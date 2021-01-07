using Models;
using System.Linq;
using System.Threading.Tasks;

namespace WriteRepositories
{
    public interface INHRepository<T> where T : class
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        IQueryable<Driver> Drivers { get; }
        IQueryable<Application> Applications { get; }
        IQueryable<Address> Addresses { get; }
        IQueryable<FuelCard> FuelCards { get; }
        IQueryable<T> GenericRepository { get; }
    }
}
