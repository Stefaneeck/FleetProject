using System;
using System.Collections.Generic;
using ModelsStandard.Enums;

namespace ModelsStandard
{
    public class Tankkaart : IIdentifiable
    {
        public long Id { get; set; }
        public int Kaartnummer { get; set; }
        public DateTime GeldigheidsDatum { get; set; }
        public int Pincode { get; set; }
        public AuthenticatieTypes AuthType { get; set; }
        public string Opties { get; set; }
    }
}
