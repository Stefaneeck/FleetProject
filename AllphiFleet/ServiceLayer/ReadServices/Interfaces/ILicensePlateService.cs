using DTO.LicensePlate;
using System.Collections.Generic;

namespace ReadServices.Interfaces
{
    public interface ILicensePlateService
    {
        public IEnumerable<LicensePlateDTO> GetLicensePlates();
        public LicensePlateDTO GetLicensePlate(long id);
    }
}
