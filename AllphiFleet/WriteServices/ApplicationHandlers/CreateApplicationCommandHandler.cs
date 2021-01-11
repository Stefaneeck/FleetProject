using Commands.ApplicationCommands;
using MediatR;
using Models;
using SendGrid;
using SendGrid.Helpers.Mail;
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

                //not making objects anyomore because we pass an existing id and altered the NH mapping
                VehicleId = command.CreateApplicationDTO.VehicleId,
                DriverId = command.CreateApplicationDTO.DriverId

                /*
                Vehicle = new Vehicle
                {
                    //not creating vehicle anymore from create application, just enter existing vehicle id
                 
                    Id = 0,
                    FuelType = command.CreateApplicationDTO.Vehicle.FuelType,
                    VehicleType = command.CreateApplicationDTO.Vehicle.VehicleType,
                    ChassisNr = command.CreateApplicationDTO.Vehicle.ChassisNr,
                    Mileage = command.CreateApplicationDTO.Vehicle.Mileage
                   

                    //Id = command.CreateApplicationDTO.Vehicle.Id

                    Id = command.CreateApplicationDTO.VehicleId
                },

                

                /*
                Driver = new Driver
                {
                    //Id = command.CreateApplicationDTO.Driver.Id

                    Id = command.CreateApplicationDTO.DriverId
                },
                */

            };
            
            _context.BeginTransaction();

            try
            {
                await _context.Save(application);
                await _context.Commit();

                //send mail
                await SendMail(application);
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

        private static async Task SendMail(Application application)
        {
            //created in windows, restart VS if null after adding
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("stefan.eeckhoudt@allphi.eu", "Stefan Eeckhoudt");
            var subject = "New application with type " + application.ApplicationType.ToString();
            var to = new EmailAddress("stefan.eeckhoudt@gmail.com", "Stefan Eeckhoudt");
            var plainTextContent = $"A new application has been created. " +
                $"Details: " +
                $"Application type: {application.ApplicationType.ToString()} " +
                $"Application date: {application.ApplicationDate.ToShortDateString()}" +
                $"Application status: {application.ApplicationStatus.ToString()}" +
                $"Dates possible:  {application.PossibleDates }";
            var htmlContent = $"A new application has been created.<br />" +
                $" Details: <br /> " +
                $"Application type: { application.ApplicationType} <br /> " +
                $"Application date: {application.ApplicationDate.ToShortDateString()} <br />" +
                $"Application status: {application.ApplicationStatus} <br />" +
                $"Dates possible:  {application.PossibleDates }"; ;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
