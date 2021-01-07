using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
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

        //circular reference vermijden
        //beter oplossing, nog nodig?
        [JsonIgnore]
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
