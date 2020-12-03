using DTO;
using System.Collections.Generic;

namespace ReadServices.Interfaces
{
    public interface IFactuurService
    {
        public IEnumerable<FactuurDTO> GetFacturen(DriverFilter filter);
        public FactuurDTO GetFactuur(long id);
    }
}
