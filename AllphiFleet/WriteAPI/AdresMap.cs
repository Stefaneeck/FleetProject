using Models;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteAPI
{
    public class AdresMap : ClassMapping<Adres>
    {
        public AdresMap()
        {
            this.Table("Adressen");

            this.Id(a => a.Id);
            this.Property(a => a.Straat);
            this.Property(a => a.Nummer);
            this.Property(a => a.Stad);
            this.Property(a => a.Postcode);

            /*
            this.Bag(x => x.Chauffeurs, mapper => {
                mapper.Inverse(false);
                mapper.Cascade(Cascade.All);
                mapper.Key(k => k.Column("AdresId"));
                });

             */
        }

    }
}
