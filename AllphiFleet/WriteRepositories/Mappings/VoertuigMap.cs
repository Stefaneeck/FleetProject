using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteRepositories.Mappings
{
    public class VoertuigMap : ClassMapping<Voertuig>
    {
        public VoertuigMap()
        {
            //hier geen aparte delete voor
            this.Table("Voertuig");

            this.Id(v => v.Id, v =>
            {
                v.Generator(Generators.Native);
                v.Type(NHibernateUtil.Int64);
                v.Column("Id");
                v.UnsavedValue(0);
            });

            //this.Property(v => v.Aanvragen);
            this.Property(v => v.ChassisNr);
            this.Property(v => v.KilometerStand);
            //this.Property(v => v.Nummerplaten);
            //this.Property(v => v.OnderhoudsBeurten);
            this.Property(v => v.TypeBrandStof);
            this.Property(v => v.TypeWagen);


            Bag(x => x.Aanvragen, map =>
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
