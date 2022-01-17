using Models.Enums;
using System;

namespace DTO
{
    public class FuelCardDTO
    {
        public long Id { get; set; }
        public int CardNumber { get; set; }
        public DateTime ValidUntilDate { get; set; }
        public int Pincode { get; set; }
        public AuthenticationTypes AuthType { get; set; }
        public string Options { get; set; }
        public bool Active { get; set; }
    }
}
