using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DTO;
using Repositories.Models;

namespace Repositories
{
    public class ChauffeurRepository : IDataRepository<ChauffeurDTO>
    {
        readonly ChauffeurContext _chauffeurContext;
        private readonly IMapper _mapper;
        public ChauffeurRepository(ChauffeurContext context, IMapper mapper)
        {
            _chauffeurContext = context;
            _mapper = mapper;
        }
        public IEnumerable<ChauffeurDTO> GetAll()
        {
            //return _chauffeurContext.Chauffeurs.ToList();

            //chauffeurs ophalen, dan mappen naar DTO
            var chauffeurs = _chauffeurContext.Chauffeurs.ToList();

            //service.mapchauffeurnaardto..
            return _mapper.Map<ChauffeurDTO[]>(chauffeurs);
        }
        public ChauffeurDTO Get(long id)
        {
            //chauffeur ophalen, dan mappen naar DTO
            Chauffeur c = _chauffeurContext.Chauffeurs
                  .FirstOrDefault(e => e.ChauffeurId == id);

            return _mapper.Map<ChauffeurDTO>(c);
        }
        public void Add(ChauffeurDTO entity)
        {
            //mappen van DTO naar chauffeur
            Chauffeur c = _mapper.Map<Chauffeur>(entity);

            _chauffeurContext.Chauffeurs.Add(c);
            _chauffeurContext.SaveChanges();
        }
        public void Update(ChauffeurDTO chauffeur, ChauffeurDTO entity)
        {
            //mappen van DTO naar chauffeur
            Chauffeur c = _mapper.Map<Chauffeur>(entity);

            chauffeur.Naam = c.Naam;
            chauffeur.Voornaam = c.Voornaam;
            chauffeur.Adres = c.Adres;
            chauffeur.GeboorteDatum = c.GeboorteDatum;
            chauffeur.RijksRegisterNummer = c.RijksRegisterNummer;
            chauffeur.TypeRijbewijs = c.TypeRijbewijs;
            chauffeur.Actief = c.Actief;

            _chauffeurContext.SaveChanges();
        }
        public void Delete(ChauffeurDTO chauffeurDTO)
        {
            //mappen van DTO naar chauffeur
            Chauffeur c = _mapper.Map<Chauffeur>(chauffeurDTO);

            _chauffeurContext.Chauffeurs.Remove(c);
            _chauffeurContext.SaveChanges();
        }
    }
}
