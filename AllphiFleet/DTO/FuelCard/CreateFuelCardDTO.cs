using Models.Enums;
using System;

namespace DTO
{
    public class CreateFuelCardDTO
    {
        public int CardNumber { get; set; }
        public DateTime ValidUntilDate { get; set; }
        public int Pincode { get; set; }
        public AuthenticationTypes AuthType { get; set; }
        public string Options { get; set; }
    }
}
