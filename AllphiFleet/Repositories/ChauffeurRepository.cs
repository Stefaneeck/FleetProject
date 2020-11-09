using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositories
{
    public class ChauffeurRepository : IDataRepository<Chauffeur>
    {
        readonly ChauffeurContext _chauffeurContext;
        public ChauffeurRepository(ChauffeurContext context)
        {
            _chauffeurContext = context;
        }
        public IEnumerable<Chauffeur> GetAll()
        {
            return _chauffeurContext.Chauffeurs.ToList();
        }
        public Chauffeur Get(long id)
        {
            return _chauffeurContext.Chauffeurs
                  .FirstOrDefault(e => e.ChauffeurId == id);
        }
        public void Add(Chauffeur entity)
        {
            _chauffeurContext.Chauffeurs.Add(entity);
            _chauffeurContext.SaveChanges();
        }
        public void Update(Chauffeur chauffeur, Chauffeur entity)
        {
            chauffeur.Naam = entity.Naam;
            chauffeur.Voornaam = entity.Voornaam;
            chauffeur.Adres = entity.Adres;
            chauffeur.GeboorteDatum = entity.GeboorteDatum;
            chauffeur.RijksRegisterNummer = entity.RijksRegisterNummer;
            chauffeur.TypeRijbewijs = entity.TypeRijbewijs;
            chauffeur.Actief = entity.Actief;

            _chauffeurContext.SaveChanges();
        }
        public void Delete(Chauffeur chauffeur)
        {
            _chauffeurContext.Chauffeurs.Remove(chauffeur);
            _chauffeurContext.SaveChanges();
        }
    }
}
