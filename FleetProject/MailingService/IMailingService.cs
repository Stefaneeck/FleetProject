using Models;
using System.Threading.Tasks;

namespace MailingService
{
    public interface IMailingService
    {
        Task SendApplicationCreatedMail(Application application);
        Task SendApplicationApprovedMail(Application application);
    }
}
