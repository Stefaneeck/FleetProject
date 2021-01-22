using Models.Enums;
using System;

namespace DTO
{
    public class UpdateApplicationDTO
    {
        public long Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public ApplicationTypes ApplicationType { get; set; }
        public string PossibleDates { get; set; }
        public ApplicationStatuses ApplicationStatus { get; set; }
        public long VehicleId { get; set; }
        //for mailing details
        public DriverDTO Driver { get; set; }
        public long DriverId { get; set; }
        public bool Approved { get; set; }
    }
}
