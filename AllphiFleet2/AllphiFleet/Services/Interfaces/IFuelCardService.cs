using DTO;
using System.Collections.Generic;

namespace ReadServices.Interfaces
{
    public interface IFuelCardService
    {
        public IEnumerable<FuelCardDTO> GetFuelCards();
        public FuelCardDTO GetFuelCard(long id);
        public long GetFuelCardByCardNumber(int cardNumber);
    }
}
