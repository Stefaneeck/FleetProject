using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteAPI.DataLayer.Repositories;

namespace WriteAPI.Features.AdresFeatures
{
    public class UpdateAdresCommandHandler : IRequestHandler<UpdateAdresCommand, Unit>
    {
        private readonly INHRepository<Adres> _adresContext;
        public UpdateAdresCommandHandler(INHRepository<Adres> adresContext)
        {
            _adresContext = adresContext;
        }
        public async Task<Unit> Handle(UpdateAdresCommand command, CancellationToken cancellationToken)
        {

            var adres = new Adres
            {
                Id = command.UpdateAdresDTO.Id,

                Straat = command.UpdateAdresDTO.Straat,
                Nummer = command.UpdateAdresDTO.Nummer,
                Stad = command.UpdateAdresDTO.Stad,
                Postcode = command.UpdateAdresDTO.Postcode

            };

            _adresContext.BeginTransaction();

            try
            {
                await _adresContext.Update(adres);
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
