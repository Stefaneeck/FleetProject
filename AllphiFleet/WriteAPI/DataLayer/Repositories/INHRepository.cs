using Models;
using System.Linq;
using System.Threading.Tasks;

namespace WriteAPI.DataLayer.Repositories
{
    //+- dbcontext
    //generiek maken
    public interface INHRepository<T> where T : class
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(T entity);
        Task Delete(T entity);
        IQueryable<Chauffeur> Chauffeurs { get; }
        IQueryable<Aanvraag> Aanvragen { get; }
        IQueryable<Adres> Adressen { get; }
        IQueryable<Tankkaart> Tankkaarten { get; }
    }
}
