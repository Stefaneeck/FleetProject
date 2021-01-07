using Models;
using Models.Enums;
using System;

namespace DTO
{
    public class CreateApplicationDTO
    {
        public DateTime ApplicationDate { get; set; }
        public ApplicationTypes ApplicationType { get; set; }
        public string PossibleDates { get; set; }
        public ApplicationStatuses ApplicationStatus { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
