using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IAdresService
    {
        public IEnumerable<AdresDTO> GetAdressen(DriverFilter filter);
        public AdresDTO GetAdres(long id);
    }
}
