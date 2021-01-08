using System.Collections.Generic;

namespace ModelsStandard
{
    public class Address : IIdentifiable
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
    }
}
