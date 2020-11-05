using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AllphiFleet.Models
{
    [Table("chauffeur")]
    public class Chauffeur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ChauffeurId { get; set; }

        [Required(ErrorMessage = "Naam is verplicht.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht.")]
        public string Voornaam { get; set; }

        //hier klasse adres voor maken
        [Required(ErrorMessage = "Adres is verplicht.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Geboortedatum is verplicht.")]
        public DateTime GeboorteDatum { get; set; }

        //todo validatie
        [Required(ErrorMessage = "Rijksregisternummer is verplicht.")]
        public string RijksRegisterNummer { get; set; }

        //enum nog aanmaken
        public string TypeRijbewijs { get; set; }
        public bool Actief { get; set; }
    }
}
