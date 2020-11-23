using Models;
using System.Linq;
using System.Threading.Tasks;

namespace WriteAPI
{
    //+- dbcontext
    //generiek maken
    public interface IMapperSession
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(Chauffeur entity);
        Task Delete(Chauffeur entity);
        IQueryable<Chauffeur> Chauffeurs { get; }
    }
}
