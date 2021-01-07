using Commands.ApplicationCommands;
using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.ApplicationHandlers
{
    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, int>
    {
        private readonly INHRepository<Application> _context;
        public CreateApplicationCommandHandler(INHRepository<Application> context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            var application = new Application
            {
                ApplicationDate = command.CreateApplicationDTO.ApplicationDate,
                ApplicationType = command.CreateApplicationDTO.ApplicationType,
                PossibleDates = command.CreateApplicationDTO.PossibleDates,
                ApplicationStatus = command.CreateApplicationDTO.ApplicationStatus,

                Vehicle = new Vehicle
                {
                    Id = command.CreateApplicationDTO.Vehicle.Id
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
                await _context.Save(application);
                await _context.Commit();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                await _context.Rollback();
            }
            
            return (int)application.Id;
        }
    }
}
