using ModelsStandard.Enums;
using System;

namespace ModelsStandard
{
    public class Chauffeur : IIdentifiable
    {
        //cannot yet translate, coming in readapi in dutch 
        public long Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string RijksRegisterNummer { get; set; }
        public RijbewijsTypes TypeRijbewijs { get; set; }
        public bool Actief { get; set; }
        public Adres Adres { get; set; }
        public Tankkaart Tankkaart { get; set; }

    }
}

