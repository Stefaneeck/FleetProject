using System;


namespace Models
{
    public class Chauffeur : IIdentifiable
    {
        //annotations gewijzigd naar fluentapi om makkelijker met nhibernate samen te kunnen werken
        public long Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        //todo validatie
        public string RijksRegisterNummer { get; set; }
        public RijbewijsTypes TypeRijbewijs { get; set; }
        public bool Actief { get; set; }

        //rel adres
        public long AdresId { get; set; }
        public Adres Adres { get; set; }

        //rel tankkaart
        public long TankkaartId { get; set; }
        public Tankkaart Tankkaart { get; set; }

    }
}

