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
                mapper.Inverse(true);
                mapper.Cascade(Cascade.None);
                mapper.Key(k =>
                {
                    k.Column("AdresId");
                    //nhibernate will insert the child with parent id already set
                    k.NotNullable(true);
                }
                );
                mapper.Lazy(CollectionLazy.Lazy);
                },
                r => r.OneToMany()
            );
          
             */
        }

    }
}
