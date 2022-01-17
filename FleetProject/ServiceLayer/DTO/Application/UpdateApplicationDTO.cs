using Models.Enums;
using System;

namespace DTO
{
    public class UpdateApplicationDTO
    {
        public long Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public ApplicationTypes ApplicationType { get; set; }
        public DateTime PossibleDate1 { get; set; }
        public DateTime PossibleDate2 { get; set; }
        public ApplicationStatuses ApplicationStatus { get; set; }
        public long VehicleId { get; set; }
        //for mailing details
        public DriverDTO Driver { get; set; }
        public long DriverId { get; set; }
        public bool Approved { get; set; }
    }
}
