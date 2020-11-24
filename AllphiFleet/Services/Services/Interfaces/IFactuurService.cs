using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IFactuurService
    {
        public IEnumerable<FactuurDTO> GetFacturen(DriverFilter filter);
        public FactuurDTO GetFactuur(long id);
    }
}
