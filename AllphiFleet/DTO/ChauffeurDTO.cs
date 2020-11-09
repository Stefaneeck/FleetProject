using System;

namespace DTO
{
    public class ChauffeurDTO
    {
        public enum RijbewijsTypes
        {
            AM,
            A,
            B,
            C,
            D,
            G
        }

        public long ChauffeurId { get; set; }

        public string Naam { get; set; }

        public string Voornaam { get; set; }

        public string Adres { get; set; }

        public DateTime GeboorteDatum { get; set; }

        public string RijksRegisterNummer { get; set; }

        public RijbewijsTypes TypeRijbewijs { get; set; }
        
        //ter voorbeeld voor mapper in comment gezet
        //public bool Actief { get; set; }
    }
}
