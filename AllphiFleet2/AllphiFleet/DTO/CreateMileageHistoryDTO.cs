
namespace DTO
{
    public class CreateMileageHistoryDTO
    {
        public virtual long Id { get; set; }
        public virtual long VehicleId { get; set; }
        public virtual int Mileage { get; set; }
    }
}
