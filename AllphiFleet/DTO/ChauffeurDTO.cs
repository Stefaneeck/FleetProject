using Models.Enums;
using System;

namespace DTO
{
    public class ChauffeurDTO
    {
        public long Id { get; set; }

        public string Naam { get; set; }

        public string Voornaam { get; set; }

        public AdresDTO Adres { get; set; }

        public DateTime GeboorteDatum { get; set; }

        public string RijksRegisterNummer { get; set; }

        public RijbewijsTypes TypeRijbewijs { get; set; }

        public TankkaartDTO Tankkaart { get; set; }
        
        public bool Actief { get; set; }
    }
}
