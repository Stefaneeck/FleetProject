﻿using Models.Enums;
using System;

namespace DTO
{
    public class CreateTankkaartDTO
    {
        public int Kaartnummer { get; set; }
        public DateTime GeldigheidsDatum { get; set; }
        public int Pincode { get; set; }
        public AuthenticatieTypes AuthType { get; set; }
        public string Opties { get; set; }
    }
}