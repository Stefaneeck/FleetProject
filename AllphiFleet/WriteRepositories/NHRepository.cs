using Models;
using NHibernate;
using System.Linq;
using System.Threading.Tasks;

namespace WriteRepositories
{
    //+- concrete dbcontext implementatie
    public class NHRepository<T> : INHRepository<T> where T : class, IIdentifiable
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHRepository(ISession session)
        {
            _session = session;
        }

        public IQueryable<Chauffeur> Chauffeurs => _session.Query<Chauffeur>();
        public IQueryable<Aanvraag> Aanvragen => _session.Query<Aanvraag>();
        public IQueryable<Adres> Adressen => _session.Query<Adres>();

        public IQueryable<Tankkaart> Tankkaarten => _session.Query<Tankkaart>();

        public IQueryable<T> GenericRepository => _session.Query<T>();

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
            if (_transaction == null)
                throw new System.Exception();
        }

        public async Task Commit()
        {
            if(_transaction != null)
                await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task Save(T entity)
        {
            //_session.Evict(entity);

            await _session.SaveOrUpdateAsync(entity);
            //await _session.FlushAsync();
        }

        /*
        public async Task Delete(long id)
        {
            await _session.DeleteAsync((int)id);
        }

        */
        public async Task Delete(T entity)
        {
            await _session.DeleteAsync(entity);
        }

        public async Task Update(T entity)
        {
            //hoe Chauffeurs generic maken? moet Adressen.FirstOrDefault zijn als er een adres binnenkomt
            //var existingEntity = Chauffeurs.FirstOrDefault(c => c.Id == entity.Id);

            var existingEntity = GenericRepository.FirstOrDefault(c => c.Id == entity.Id);

            if (existingEntity == null)
                throw new System.Exception(entity.Id.ToString());

            await _session.MergeAsync(entity);
        }
    }
}
