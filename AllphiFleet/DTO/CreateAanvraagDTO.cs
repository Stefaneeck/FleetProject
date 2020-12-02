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

        //enkel id van voertuig nodig, voertuigid ipv voertuig ok?
        public Voertuig Voertuig { get; set; }
    }
}
