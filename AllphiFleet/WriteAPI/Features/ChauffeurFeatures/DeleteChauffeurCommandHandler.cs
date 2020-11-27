using AutoMapper;
using MediatR;
using Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteAPI.DataLayer.Repositories;

namespace WriteAPI.Features.ChauffeurFeatures
{
    public class DeleteChauffeurCommandHandler : IRequestHandler<DeleteChauffeurCommand, int>
    {
        private readonly INHRepository<Chauffeur> _context;
        public DeleteChauffeurCommandHandler(INHRepository<Chauffeur> context, IMapper mapper)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteChauffeurCommand command, CancellationToken cancellationToken)
        {
            /*
            var chauffeur = new Chauffeur
            {
                Id = command.Id
            };
            */

            //kijken of chauffeur al bestaat
            var chauffeur = new Chauffeur();
            chauffeur = _context.Chauffeurs.ToList().FirstOrDefault(e => e.Id == command.Id);
            if(chauffeur == null)
                //return not found
                //hoe doen met mediatr?

            //undo later
            //chauffeur.Tankkaart = _mapper.Map<Tankkaart>(command.CreateChauffeurDTO.Tankkaart);


            //_context.Chauffeurs.Add(chauffeur);

            //try catch rondzetten
            //buiten try begintransaction
            // save commit binnen try block
            //catchblok rollback

            //todo controleren of chauffeur wel bestaat
            _context.BeginTransaction();

            //await _context.Delete(chauffeur);
            //await _context.Delete(command.DeleteChauffeurDTO.Id);
            await _context.Delete(chauffeur);
            await _context.Commit();

            //moet niets teruggeven
            //aanpassen
            //unit in mediatr equivalent van void
            return (int)command.Id;
        }
    }
}
