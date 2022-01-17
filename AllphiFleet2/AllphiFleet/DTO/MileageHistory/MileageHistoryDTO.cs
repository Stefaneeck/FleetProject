using System;

namespace DTO.MileageHistory
{
    public class MileageHistoryDTO
    {
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        public int Mileage { get; set; }
    }
}
