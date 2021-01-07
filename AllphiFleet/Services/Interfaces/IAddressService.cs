using DTO;
using System.Collections.Generic;

namespace ReadServices.Interfaces
{
    public interface IAddressService
    {
        public IEnumerable<AddressDTO> GetAddresses();
        public AddressDTO GetAddress(long id);
    }
}
