using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class AddressDTO
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }

        //jsonignore voor circular reference bij ophalen van data te omzeilen. betere oplossing zoeken?
        //[JsonIgnore]
        //public ICollection<Chauffeur> Chauffeurs { get; set; }
    }
}
