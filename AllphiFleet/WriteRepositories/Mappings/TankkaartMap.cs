using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteRepositories.Mappings
{
    public class TankkaartMap : ClassMapping<Tankkaart>
    {
        public TankkaartMap()
        {
            //hier aparte delete voor
            this.Table("Tankkaarten");

            this.Id(t => t.Id, t =>
            {
                t.Generator(Generators.Native);
                t.Type(NHibernateUtil.Int64);
                t.Column("Id");
                t.UnsavedValue(0);
            });

            this.Property(t => t.Kaartnummer);
            this.Property(t => t.GeldigheidsDatum);
            this.Property(t => t.Pincode);
            this.Property(t => t.AuthType);
            this.Property(t => t.Opties);

            Bag(x => x.Chauffeurs, map =>
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
