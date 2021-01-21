using Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace MailingService
{
    public class MailingService : IMailingService
    {

        public async Task SendApplicationMail(Application application)
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
