using Models;
using NHibernate.Mapping.ByCode.Conformist;

namespace WriteAPI
{
    public class ChauffeurMap : ClassMapping<Chauffeur>
    {
        public ChauffeurMap()
        {
            //dbo.Chauffeurs werkte niet
            this.Table("Chauffeurs");

            /*
            this.Id(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int64);
                x.Column("Id");
                x.UnsavedValue(0);
            });
            */
            this.Id(c => c.Id);
            this.Property(c => c.Naam);
            this.Property(c => c.Voornaam);
            this.Property(c => c.GeboorteDatum);
            this.Property(c => c.RijksRegisterNummer);
            this.Property(c => c.TypeRijbewijs);
            this.Property(c => c.Actief);
            //hoe adresid en tankkaartid niet tonen?
            this.Property(c => c.AdresId);

            this.ManyToOne(c => c.Adres, a =>
            {
                a.Column("adresId");
            });

            this.Property(c => c.TankkaartId);
            this.ManyToOne(p => p.Tankkaart, t =>
            {
                t.Column("tankkaartId");
            });
        }
    }
}
