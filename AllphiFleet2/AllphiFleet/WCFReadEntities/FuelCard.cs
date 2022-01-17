using System;
using System.Runtime.Serialization;

namespace WCFReadEntities
{
    [DataContract]
    public class FuelCard
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public int CardNumber { get; set; }

        [DataMember]
        public DateTime ValidUntilDate { get; set; }

        [DataMember]
        public int Pincode { get; set; }

        [DataMember]
        public int AuthType { get; set; }

        [DataMember]
        public string Options { get; set; }
    }
}
