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
            //hier aparte delete voor
            this.Table("FuelCards");

            this.Id(t => t.Id, t =>
            {
                t.Generator(Generators.Native);
                t.Type(NHibernateUtil.Int64);
                t.Column("Id");
                t.UnsavedValue(0);
            });

            this.Property(t => t.CardNumber);
            this.Property(t => t.ValidUntilDate);
            this.Property(t => t.Pincode);
            this.Property(t => t.AuthType);
            this.Property(t => t.Options);

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
