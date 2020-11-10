using System.Collections.Generic;


namespace Repositories
{
    public interface IDataReadRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);

        /*
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
        */
    }
}
