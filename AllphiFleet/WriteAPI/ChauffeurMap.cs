using Models;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WriteAPI
{
    public class ChauffeurMap : ClassMapping<Chauffeur>
    {
        public ChauffeurMap()
        {
            //dbo.Chauffeurs werkte niet
            this.Table("Chauffeurs");

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
