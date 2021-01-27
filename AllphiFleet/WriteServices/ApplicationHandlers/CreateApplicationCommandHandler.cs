using Commands.ApplicationCommands;
using MailingService;
using MediatR;
using Models;
using ReadServices.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.ApplicationHandlers
{
    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, int>
    {
        private readonly INHRepository<Application> _context;
        private readonly IMailingService _mailingService;
        
        public CreateApplicationCommandHandler(INHRepository<Application> context, IMailingService mailingService)
        {
            _context = context;
            _mailingService = mailingService;
        }
        public async Task<int> Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            Application application = null;
            //we have driver email, get driver id matching the email
            //needed to link IS4 user to driver by linking IS4 email to driver email

            //application created as normal user, get id by email
            if(command.CreateApplicationDTO.DriverEmail != null)
            {
                var driverId = _context.Drivers.First(driver => driver.Email.ToLower() == command.CreateApplicationDTO.DriverEmail.ToLower()).Id;
                application = new Application
                {
                    ApplicationDate = command.CreateApplicationDTO.ApplicationDate,
                    ApplicationType = command.CreateApplicationDTO.ApplicationType,
                    PossibleDates = command.CreateApplicationDTO.PossibleDates,
                    ApplicationStatus = command.CreateApplicationDTO.ApplicationStatus,

                    //not making objects anyomore because we pass an existing id and altered the NH mapping
                    VehicleId = command.CreateApplicationDTO.VehicleId,
                    DriverId = driverId
                };
            }
            // application created as admin, id already provided
            else
            {
                application = new Application
                {
                    ApplicationDate = command.CreateApplicationDTO.ApplicationDate,
                    ApplicationType = command.CreateApplicationDTO.ApplicationType,
                    PossibleDates = command.CreateApplicationDTO.PossibleDates,
                    ApplicationStatus = command.CreateApplicationDTO.ApplicationStatus,

                    //not making objects anyomore because we pass an existing id and altered the NH mapping
                    VehicleId = command.CreateApplicationDTO.VehicleId,
                    DriverId = command.CreateApplicationDTO.DriverId
                };
            } 
            _context.BeginTransaction();

            try
            {
                await _context.Save(application);
                await _context.Commit();

                //send mail
                await _mailingService.SendApplicationCreatedMail(application);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //added because NH does not write much info in console
                Console.WriteLine(e.InnerException.ToString());
                await _context.Rollback();
            }

            return (int)application.Id;
        }
    }
}
