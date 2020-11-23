using Models;
using NHibernate;
using System.Linq;
using System.Threading.Tasks;

namespace WriteAPI.DataLayer.Repositories
{
    //+- concrete dbcontext implementatie
    public class NHibernateMapperSession : IMapperSession
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHibernateMapperSession(ISession session)
        {
            _session = session;
        }

        public IQueryable<Chauffeur> Chauffeurs => _session.Query<Chauffeur>();

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
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

        public async Task Save(Chauffeur entity)
        {
            await _session.SaveOrUpdateAsync(entity);
            //await _session.FlushAsync();
        }

        public async Task Delete(Chauffeur entity)
        {
            await _session.DeleteAsync(entity);
        }
    }
}
