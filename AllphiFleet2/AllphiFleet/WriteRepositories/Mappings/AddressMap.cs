using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteRepositories.Mappings
{
    public class AddressMap : ClassMapping<Address>
    {
        public AddressMap()
        {
            //no seperate delete for this
            this.Table("Addresses");

            this.Id(a => a.Id, a =>
            {
                a.Generator(Generators.Native);
                a.Type(NHibernateUtil.Int64);
                a.Column("Id");
                a.UnsavedValue(0);
            });

            this.Property(a => a.Street);
            this.Property(a => a.Number);
            this.Property(a => a.City);
            this.Property(a => a.Zipcode);

            Bag(x => x.Drivers, map =>
            {
                map.Key(k =>
                {
                    k.Column(col => col.Name("Id"));
                });
                //if address is deleted, nothing happens?
                //delete orphans?
                map.Cascade(Cascade.None);
                map.Inverse(true);

                map.Lazy(CollectionLazy.Lazy);
            },
            action => action.OneToMany());
        }

    }
}
