using AutoMapper;
using MediatR;
using Models;
using System.Threading;
using System.Threading.Tasks;
using WriteAPI.DataLayer.Repositories;

namespace WriteAPI.Features.ChauffeurFeatures
{
    public class CreateChauffeurCommandHandler : IRequestHandler<CreateChauffeurCommand, int>
    {
        private readonly INHRepository<Chauffeur> _context;
        private readonly INHRepository<Adres> _adresContext;
        private readonly IMapper _mapper;
        public CreateChauffeurCommandHandler(INHRepository<Chauffeur> context, IMapper mapper, INHRepository<Adres> adresContext)
        {
            _context = context;
            _mapper = mapper;

            _adresContext = adresContext;
        }
        public async Task<int> Handle(CreateChauffeurCommand command, CancellationToken cancellationToken)
        {

            //mapping maken
            var chauffeur = new Chauffeur();

            
            chauffeur.Naam = command.CreateChauffeurDTO.Naam;
            chauffeur.Voornaam = command.CreateChauffeurDTO.Voornaam;
            chauffeur.GeboorteDatum = command.CreateChauffeurDTO.GeboorteDatum;
            chauffeur.RijksRegisterNummer = command.CreateChauffeurDTO.RijksRegisterNummer;
            chauffeur.TypeRijbewijs = command.CreateChauffeurDTO.TypeRijbewijs;
            chauffeur.Actief = command.CreateChauffeurDTO.Actief;

            chauffeur.TankkaartId = 4;

            chauffeur.Adres = new Adres
            {
                Id = 0,
                Straat = command.CreateChauffeurDTO.Adres.Straat,
                Nummer = command.CreateChauffeurDTO.Adres.Nummer,
                Stad = command.CreateChauffeurDTO.Adres.Stad,
                Postcode = command.CreateChauffeurDTO.Adres.Postcode
            };
            
            

            /*
            chauffeur.Naam = command.Naam;
            chauffeur.Voornaam = command.Voornaam;
            chauffeur.GeboorteDatum = command.GeboorteDatum;
            chauffeur.RijksRegisterNummer = command.RijksRegisterNummer;
            chauffeur.TypeRijbewijs = command.TypeRijbewijs;
            chauffeur.Actief = command.Actief;
            */

            //als we niet met genest object zouden werken
            //chauffeur.AdresId = command.createChauffeurDTO.AdresId;
            //chauffeur.TankkaartId = command.createChauffeurDTO.TankkaartId;
            //chauffeur.AdresId = command.createChauffeurDTO.Adres.Id;

            //adresdto naar adres mappen
            //niet hier mappen?

            //undo later
            //chauffeur.Adres = _mapper.Map<Adres>(command.CreateChauffeurDTO.Adres);

            //chauffeur.TankkaartId = command.createChauffeurDTO.Tankkaart.Id;
            //chauffeur.Tankkaart = command.createChauffeurDTO.Tankkaart;

            //undo later
            //chauffeur.Tankkaart = _mapper.Map<Tankkaart>(command.CreateChauffeurDTO.Tankkaart);


            //_context.Chauffeurs.Add(chauffeur);

            //try catch rondzetten
            //buiten try begintransaction
            // save commit binnen try block
            //catchblok rollback
            _context.BeginTransaction();
            //_adresContext.BeginTransaction();

            //await _adresContext.Save(chauffeur.Adres);
            //await _adresContext.Commit();

            await _context.Save(chauffeur);
            await _context.Commit();

            return (int)chauffeur.Id;
        }
    }
}
