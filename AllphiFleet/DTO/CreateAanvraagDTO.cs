using Models;
using Models.Enums;
using System;

namespace DTO
{
    public class CreateAanvraagDTO
    {
        public DateTime DatumAanvraag { get; set; }
        public AanvraagTypes TypeAanvraag { get; set; }
        public string GewensteData { get; set; }
        public AanvraagStatussen StatusAanvraag { get; set; }
        public Voertuig Voertuig { get; set; }
    }
}
