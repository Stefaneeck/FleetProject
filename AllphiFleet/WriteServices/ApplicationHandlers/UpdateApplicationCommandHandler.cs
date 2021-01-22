using Commands.ApplicationCommands;
using MailingService;
using MediatR;
using Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.ApplicationHandlers
{
    public class UpdateApplicationCommandHandler : IRequestHandler<UpdateApplicationCommand, Unit>
    {
        private readonly INHRepository<Application> _applicationContext;
        private readonly IMailingService _mailingService;
        public UpdateApplicationCommandHandler(INHRepository<Application> applicationContext, IMailingService mailingService)
        {
            _applicationContext = applicationContext;
            _mailingService = mailingService;
        }
        public async Task<Unit> Handle(UpdateApplicationCommand command, CancellationToken cancellationToken)
        {
            Application applicationFromDb = _applicationContext.Applications.FirstOrDefault(application => application.Id == command.UpdateApplicationDTO.Id);

            var application = new Application
            {
                Id = command.UpdateApplicationDTO.Id,
                ApplicationDate = command.UpdateApplicationDTO.ApplicationDate,
                PossibleDates = command.UpdateApplicationDTO.PossibleDates,
                ApplicationStatus = command.UpdateApplicationDTO.ApplicationStatus,
                VehicleId = command.UpdateApplicationDTO.VehicleId,
                //DriverId seperately still needed because otherwise we must change NH mapping to expect a driver object with bag etc.. but only needing id.
                //driver object here not for db,but to pass on for application email details
                DriverId = command.UpdateApplicationDTO.Driver.Id,
                Driver = new Driver {
                    Id = command.UpdateApplicationDTO.Driver.Id,
                    Name = command.UpdateApplicationDTO.Driver.Name,
                    FirstName = command.UpdateApplicationDTO.Driver.FirstName,
                    BirthDate = command.UpdateApplicationDTO.Driver.BirthDate,
                    DriverLicenseType = command.UpdateApplicationDTO.Driver.DriverLicenseType,
                    Email = command.UpdateApplicationDTO.Driver.Email,
                    Active = command.UpdateApplicationDTO.Driver.Active
                }
                ,
                ApplicationType = command.UpdateApplicationDTO.ApplicationType,
                //Approved = command.UpdateApplicationDTO.Approved
            };

            if(application.ApplicationStatus == Models.Enums.ApplicationStatuses.Approved)
            {
                await _mailingService.SendApplicationApprovedMail(application);
            }

            _applicationContext.BeginTransaction();

            try
            {
                await _applicationContext.Update(application);
                await _applicationContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);

                await _applicationContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
