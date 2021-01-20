using Commands.ApplicationCommands;
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
        public UpdateApplicationCommandHandler(INHRepository<Application> applicationContext)
        {
            _applicationContext = applicationContext;
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
                //Todo: not needed anymore, driver object passed in
                DriverId = command.UpdateApplicationDTO.DriverId,
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
                Approved = command.UpdateApplicationDTO.Approved
            };

            if(application.Approved)
            {
                await SendMail(application);
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

        //todo: move to own project or dedicated service
        private static async Task SendMail(Application application)
        {
            //created in windows, restart VS if null after adding
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("stefan.eeckhoudt@allphi.eu", "Stefan Eeckhoudt");
            var subject = "Your application from " + application.ApplicationDate.ToShortDateString() + " has been approved.";
            var to = new EmailAddress(application.Driver.Email, application.Driver.FirstName + " " + application.Driver.Name);
            var plainTextContent = $"Dear {application.Driver.FirstName }, your application with date {application.ApplicationDate.ToShortDateString()} has been approved. " +
                $"Details: " +
                $"Application type: {application.ApplicationType.ToString()} " +
                $"Application date: {application.ApplicationDate.ToShortDateString()}" +
                $"Application status: {application.ApplicationStatus.ToString()}" +
                $"Dates possible:  {application.PossibleDates }";
            var htmlContent = $"Dear {application.Driver.FirstName }, <br /><br /> your application with date {application.ApplicationDate.ToShortDateString()} has been approved. <br />" +
                $" Details: <br /> " +
                $"Application type: {application.ApplicationType} <br /> " +
                $"Application date: {application.ApplicationDate.ToShortDateString()} <br />" +
                $"Application status: {application.ApplicationStatus} <br />" +
                $"Dates possible:  {application.PossibleDates }"; ;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
