using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteAPI.DataLayer.Repositories;

namespace WriteAPI.Features.AdresFeatures
{
    public class DeleteAdresCommandHandler : IRequestHandler<DeleteAdresCommand, Unit>
    {
        private readonly INHRepository<Adres> _adresContext;
        public DeleteAdresCommandHandler(INHRepository<Adres> adresContext)
        {
            _adresContext = adresContext;
        }

        //je moet altijd iets teruggeven met mediatr
        //unit is void equivalent van mediatr
        public async Task<Unit> Handle(DeleteAdresCommand command, CancellationToken cancellationToken)
        {
            //adres ophalen
            var adres = _adresContext.Adressen.FirstOrDefault(a => a.Id == command.Id);

            _adresContext.BeginTransaction();

            try
            {
                await _adresContext.Delete(adres);
                await _adresContext.Commit();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _adresContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
