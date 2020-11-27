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
                map.Cascade(Cascade.None);
                map.Inverse(true);
            },
            action => action.OneToMany());
        }

    }
}
