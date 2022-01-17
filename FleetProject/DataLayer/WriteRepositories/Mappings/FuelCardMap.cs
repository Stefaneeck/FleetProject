using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteRepositories.Mappings
{
    public class FuelCardMap : ClassMapping<FuelCard>
    {
        public FuelCardMap()
        {
            //separate delete for this
            this.Table("FuelCards");

            this.Id(f => f.Id, f =>
            {
                f.Generator(Generators.Native);
                f.Type(NHibernateUtil.Int64);
                f.Column("Id");
                f.UnsavedValue(0);
            });

            this.Property(f => f.CardNumber);
            this.Property(f => f.ValidUntilDate);
            this.Property(f => f.Pincode);
            this.Property(f => f.AuthType);
            this.Property(f => f.Options);
            this.Property(f => f.Active);

            Bag(x => x.Drivers, map =>
            {
                map.Key(k =>
                {
                    k.Column(col => col.Name("Id"));
                });
                map.Cascade(Cascade.None);
                map.Inverse(true);

                map.Lazy(CollectionLazy.Lazy);
            },
            action => action.OneToMany());
        }
    }
}
