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
        private readonly IMapper _mapper;
        public CreateChauffeurCommandHandler(INHRepository<Chauffeur> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateChauffeurCommand command, CancellationToken cancellationToken)
        {
            //mapping maken
            var chauffeur = new Chauffeur();

            chauffeur.Naam = command.createChauffeurDTO.Naam;
            chauffeur.Voornaam = command.createChauffeurDTO.Voornaam;
            chauffeur.GeboorteDatum = command.createChauffeurDTO.GeboorteDatum;
            chauffeur.RijksRegisterNummer = command.createChauffeurDTO.RijksRegisterNummer;
            chauffeur.TypeRijbewijs = command.createChauffeurDTO.TypeRijbewijs;
            chauffeur.Actief = command.createChauffeurDTO.Actief;
            //als we niet met genest object zouden werken
            //chauffeur.AdresId = command.createChauffeurDTO.AdresId;
            //chauffeur.TankkaartId = command.createChauffeurDTO.TankkaartId;
            //chauffeur.AdresId = command.createChauffeurDTO.Adres.Id;

            //adresdto naar adres mappen
            //niet hier mappen?
            chauffeur.Adres = _mapper.Map<Adres>(command.createChauffeurDTO.Adres);

            //chauffeur.TankkaartId = command.createChauffeurDTO.Tankkaart.Id;
            //chauffeur.Tankkaart = command.createChauffeurDTO.Tankkaart;
            chauffeur.Tankkaart = _mapper.Map<Tankkaart>(command.createChauffeurDTO.Tankkaart);


            //_context.Chauffeurs.Add(chauffeur);

            //try catch rondzetten
            //buiten try begintransaction
            // save commit binnen try blokc
            //catchblok rollback
            _context.BeginTransaction();
            await _context.Save(chauffeur);
            await _context.Commit();

            return (int)chauffeur.Id;
        }
    }
}
