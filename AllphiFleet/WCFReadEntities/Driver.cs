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
        public string Naam { get; set; }

        [DataMember]
        public string Voornaam { get; set; }

        [DataMember]
        public DateTime GeboorteDatum { get; set; }

        [DataMember]
        public string RijksRegisterNummer { get; set; }

        //[DataMember]
        //public RijbewijsTypes TypeRijbewijs { get; set; }

        [DataMember]
        public bool Actief { get; set; }

        [DataMember]

        //rel adres
        public long AdresId { get; set; }

        //[DataMember]
        //public Adres Adres { get; set; }

        [DataMember]

        //rel tankkaart
        public long TankkaartId { get; set; }

        //[DataMember]
        //public Tankkaart Tankkaart { get; set; }
    }
}
