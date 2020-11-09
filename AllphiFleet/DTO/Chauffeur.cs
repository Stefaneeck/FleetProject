using System;

namespace DTO
{
    public class Chauffeur
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

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ChauffeurId { get; set; }

        //[Required(ErrorMessage = "Naam is verplicht.")]
        public string Naam { get; set; }

        //[Required(ErrorMessage = "Voornaam is verplicht.")]
        public string Voornaam { get; set; }

        //hier klasse adres voor maken
        //[Required(ErrorMessage = "Adres is verplicht.")]
        public string Adres { get; set; }

        //[Required(ErrorMessage = "Geboortedatum is verplicht.")]
        public DateTime GeboorteDatum { get; set; }

        //todo validatie
        //[Required(ErrorMessage = "Rijksregisternummer is verplicht.")]
        public string RijksRegisterNummer { get; set; }

        public RijbewijsTypes TypeRijbewijs { get; set; }

        public bool Actief { get; set; }
    }
}
