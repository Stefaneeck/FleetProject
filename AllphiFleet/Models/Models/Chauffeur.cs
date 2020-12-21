using Models.Enums;
using System;

namespace Models
{
    public class Chauffeur : IIdentifiable
    {
        //virtual to support nhibernate lazy loading
        public virtual long Id { get; set; }
        public virtual string Naam { get; set; }
        public virtual string Voornaam { get; set; }
        public virtual DateTime GeboorteDatum { get; set; }
        public virtual string RijksRegisterNummer { get; set; }
        public virtual RijbewijsTypes TypeRijbewijs { get; set; }
        public virtual bool Actief { get; set; }

        //rel adres
        public virtual long AdresId { get; set; }
        public virtual Adres Adres { get; set; }

        //rel tankkaart
        public virtual long TankkaartId { get; set; }
        public virtual Tankkaart Tankkaart { get; set; }

    }
}

