﻿using Models;
using Models.Enums;
using System;

namespace DTO
{
    public partial class ChauffeurDTO
    {
        public long Id { get; set; }

        public string Naam { get; set; }

        public string Voornaam { get; set; }

        public Adres Adres { get; set; }

        public DateTime GeboorteDatum { get; set; }

        public string RijksRegisterNummer { get; set; }

        public RijbewijsTypes TypeRijbewijs { get; set; }

        public Tankkaart Tankkaart { get; set; }
        
        public bool Actief { get; set; }
    }
}
