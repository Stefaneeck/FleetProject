using System.Runtime.Serialization;

namespace WCFReadEntities
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public int Number { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public int Zipcode { get; set; }
    }
}
