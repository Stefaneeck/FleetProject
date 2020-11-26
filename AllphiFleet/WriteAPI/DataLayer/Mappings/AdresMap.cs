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

            //this.Id(a => a.Id);
            this.Id(a => a.Id, a =>
            {
                //native = what ever is native in underlying db
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
                map.Cascade(Cascade.All);
                map.Inverse(true);
            },
            action => action.OneToMany());

            //Gebeurt in EF
            /*
              this.Bag(x => x.Chauffeurs, mapper => {
                  mapper.Inverse(true);
                  mapper.Cascade(Cascade.None);
                  mapper.Key(k =>
                  {
                      //chauffeurid
                      k.Column("Id");
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
