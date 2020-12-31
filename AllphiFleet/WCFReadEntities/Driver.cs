using System;
using System.Runtime.Serialization;

namespace WCFReadEntities
{
    [DataContract]
    public class Driver
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public string SocSecNumber { get; set; }

        //[DataMember]
        //public RijbewijsTypes TypeRijbewijs { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]

        //rel adres
        public long AddressId { get; set; }

        //[DataMember]
        //public Adres Adres { get; set; }

        [DataMember]

        //rel tankkaart
        public long FuelCardId { get; set; }

        //[DataMember]
        //public Tankkaart Tankkaart { get; set; }
    }
}
