using Models;
using System.Linq;

namespace Repositories
{
    public interface IDataReadRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(long id);

        //ter test, moet weg
        IQueryable<Chauffeur> GetAllChauffeurs();

        /*
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
        */
    }
}
