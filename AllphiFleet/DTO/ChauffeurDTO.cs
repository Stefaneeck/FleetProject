using Repositories;
using System;

namespace DTO
{

    //link met repositories voor enum, anders doen?
    public partial class ChauffeurDTO
    {
        public long ChauffeurId { get; set; }

        public string Naam { get; set; }

        public string Voornaam { get; set; }

        public string Adres { get; set; }

        public DateTime GeboorteDatum { get; set; }

        public string RijksRegisterNummer { get; set; }

        public RijbewijsTypes TypeRijbewijs { get; set; }
        
        public bool Actief { get; set; }
    }
}
