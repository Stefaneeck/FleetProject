using Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteRepositories.Mappings
{
    public class AanvraagMap : ClassMapping<Aanvraag>
    {

        public AanvraagMap()
        {
            this.Table("Aanvraag");

            this.Id(x => x.Id, x =>
            {
                x.Generator(Generators.Native);
                x.Type(NHibernateUtil.Int64);
                x.Column("Id");
                x.UnsavedValue(0);
            });

            this.Property(a => a.DatumAanvraag);
            this.Property(a => a.TypeAanvraag);
            this.Property(a => a.GewensteData);
            this.Property(a => a.StatusAanvraag);

            //rel voertuig
            //this.Property(a => a.VoertuigId);
            ManyToOne(a => a.Voertuig, map =>
            {
                map.Column("VoertuigId");
                //bij delete, delete orphans
                //cascade merge omdat we bij update merge gebruiken, als dit niet aanstaat dan update hij enkel de aanvraag
                map.Cascade(Cascade.Refresh | Cascade.Persist | Cascade.Merge);
            });
        }
    }
}
