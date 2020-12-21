using Models;
using System.Linq;

namespace ReadRepositories
{
    public interface IDataReadRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(long id);
    }
}
