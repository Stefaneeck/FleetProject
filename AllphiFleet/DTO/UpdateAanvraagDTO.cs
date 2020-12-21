using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UpdateAanvraagDTO
    {
        public long Id { get; set; }
        public DateTime DatumAanvraag { get; set; }
        public AanvraagTypes TypeAanvraag { get; set; }
        public string GewensteData { get; set; }
        public AanvraagStatussen StatusAanvraag { get; set; }
        public VoertuigDTO Voertuig { get; set; }
    }
}
