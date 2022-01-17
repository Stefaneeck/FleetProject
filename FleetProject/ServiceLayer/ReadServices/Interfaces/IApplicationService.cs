using DTO;
using System.Collections.Generic;

namespace ReadServices.Interfaces
{
    public interface IApplicationService
    {
        public IEnumerable<ApplicationDTO> GetApplications();
        public ApplicationDTO GetApplication(long id);
    }
}
