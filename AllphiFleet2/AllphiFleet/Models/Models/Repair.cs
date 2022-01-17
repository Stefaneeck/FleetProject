using System;

namespace Models
{
    public class Repair : IIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual DateTime RepairDate { get; set; }
        public virtual string DamageDescription { get; set; }

        //rel insurancecompany
        public virtual long InsuranceCompanyId { get; set; }
        public virtual InsuranceCompany InsuranceCompany { get; set; }

        //links to urls
        public virtual string Photos { get; set; }
        public virtual string Documents { get; set; }
    }
}
