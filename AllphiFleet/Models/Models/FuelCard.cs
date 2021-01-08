using System;
using System.Collections.Generic;
using Models.Enums;

namespace Models
{
    public class FuelCard : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual int CardNumber { get; set; }
        public virtual DateTime ValidUntilDate { get; set; }
        public virtual int Pincode { get; set; }
        public virtual AuthenticationTypes AuthType { get; set; }
        public virtual string Options { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
