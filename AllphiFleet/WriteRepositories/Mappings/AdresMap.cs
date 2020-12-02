using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteAPI
{
    public class AdresMap : ClassMapping<Adres>
    {
        public AdresMap()
        {
            //hier geen aparte delete voor

            this.Table("Adressen");

            this.Id(a => a.Id, a =>
            {
                a.Generator(Generators.Native);
                a.Type(NHibernateUtil.Int64);
                a.Column("Id");
                a.UnsavedValue(0);
            });

            this.Property(a => a.Straat);
            this.Property(a => a.Nummer);
            this.Property(a => a.Stad);
            this.Property(a => a.Postcode);

            Bag(x => x.Chauffeurs, map =>
            {
                map.Key(k =>
                {
                    k.Column(col => col.Name("Id"));
                });
                //als een adres verwijderd wordt, gebeurt er niets?
                //delete orphans?
                map.Cascade(Cascade.None);
                map.Inverse(true);

                map.Lazy(CollectionLazy.Lazy);
            },
            action => action.OneToMany());
        }

    }
}
