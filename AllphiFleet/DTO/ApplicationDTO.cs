﻿using Models.Enums;
using System;

namespace DTO
{
    public class ApplicationDTO
    {
        public long Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public ApplicationTypes ApplicationType { get; set; }
        public string PossibleDates { get; set; }
        public ApplicationStatuses ApplicationStatus { get; set; }
        public VehicleDTO Vehicle { get; set; }
        public DriverDTO Driver { get; set; }
    }
}