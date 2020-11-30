﻿using Models;
using Models.Enums;
using System;

namespace DTO
{
    public class AanvraagDTO
    {
        public long Id { get; set; }
        public DateTime DatumAanvraag { get; set; }
        public AanvraagTypes TypeAanvraag { get; set; }

        //ef ondersteunt geen lijsten, aparte tabel van maken of string bewerking
        public string GewensteData { get; set; }
        public AanvraagStatussen StatusAanvraag { get; set; }
        //public long VoertuigId { get; set; }

        //moet voertuigDTO worden
        public VoertuigDTO VoertuigDTO { get; set; }
    }
}
