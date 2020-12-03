using Commands.AanvraagCommands;
using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.AanvraagHandlers
{
    public class CreateAanvraagCommandHandler : IRequestHandler<CreateAanvraagCommand, int>
    {
        private readonly INHRepository<Aanvraag> _context;
        public CreateAanvraagCommandHandler(INHRepository<Aanvraag> context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateAanvraagCommand command, CancellationToken cancellationToken)
        {
            var aanvraag = new Aanvraag
            {
                DatumAanvraag = command.CreateAanvraagDTO.DatumAanvraag,
                TypeAanvraag = command.CreateAanvraagDTO.TypeAanvraag,
                GewensteData = command.CreateAanvraagDTO.GewensteData,
                StatusAanvraag = command.CreateAanvraagDTO.StatusAanvraag,

                Voertuig = new Voertuig
                {
                    Id = command.CreateAanvraagDTO.Voertuig.Id
                    /*,
                    TypeBrandStof = command.CreateChauffeurDTO.Adres.Straat,
                    TypeWagen = command.CreateChauffeurDTO.Adres.Nummer,
                    Stad = command.CreateChauffeurDTO.Adres.Stad,
                    Postcode = command.CreateChauffeurDTO.Adres.Postcode
                    */
                },

            };

            _context.BeginTransaction();

            try 
            {
                await _context.Save(aanvraag);
                await _context.Commit();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                await _context.Rollback();
            }
            
            return (int)aanvraag.Id;
        }
    }
}
