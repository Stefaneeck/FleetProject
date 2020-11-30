using AutoMapper;
using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteAPI.DataLayer.Repositories;

namespace WriteAPI.Features.AdresFeatures
{
    public class DeleteAdresCommandHandler : IRequestHandler<DeleteAdresCommand, int>
    {
        private readonly INHRepository<Adres> _adresContext;
        public DeleteAdresCommandHandler(INHRepository<Adres> adresContext)
        {
            _adresContext = adresContext;
        }
        public async Task<int> Handle(DeleteAdresCommand command, CancellationToken cancellationToken)
        {
           
            //kijken of adres bestaat
            var adres = _adresContext.Adressen.FirstOrDefault(a => a.Id == command.Id);

            //met mediatr teruggeven ipv ex
            if(adres == null)
            {
                throw new Exception("Adres bestaat niet");
            }

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

            //moet niets teruggeven
            //aanpassen
            //unit in mediatr equivalent van void

            return (int)command.Id;
        }
    }
}
