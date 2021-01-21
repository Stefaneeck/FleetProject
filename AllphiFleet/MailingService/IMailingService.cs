using Models;
using System.Threading.Tasks;

namespace MailingService
{
    public interface IMailingService
    {
        Task SendApplicationMail(Application application);
    }
}
