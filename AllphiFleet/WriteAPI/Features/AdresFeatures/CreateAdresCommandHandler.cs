using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteAPI.DataLayer.Repositories;

namespace WriteAPI.Features.AdresFeatures
{
    public class CreateAdresCommandHandler : IRequestHandler<CreateAdresCommand, int>
    {
        private readonly INHRepository<Adres> _context;

        public CreateAdresCommandHandler(INHRepository<Adres> context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateAdresCommand command, CancellationToken cancellationToken)
        {
            var adres = new Adres
            {
                Id = 0,
                Straat = command.CreateAdresDTO.Straat,
                Nummer = command.CreateAdresDTO.Nummer,
                Stad = command.CreateAdresDTO.Stad,
                Postcode = command.CreateAdresDTO.Postcode
            };

            _context.BeginTransaction();

            try
            {
                await _context.Save(adres);
                await _context.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _context.Rollback();
            }

            return (int)adres.Id;
        }
    }
}
