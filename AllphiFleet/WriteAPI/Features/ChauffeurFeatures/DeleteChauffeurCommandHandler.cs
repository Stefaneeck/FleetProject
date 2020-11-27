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
        private readonly INHRepository<Chauffeur> _chauffeurContext;
        private readonly INHRepository<Adres> _adresContext;
        private readonly INHRepository<Tankkaart> _tankkaartContext;
        public DeleteChauffeurCommandHandler(INHRepository<Chauffeur> chauffeurContext, INHRepository<Adres> adresContext, INHRepository<Tankkaart> tankkaartContext, IMapper mapper)
        {
            _chauffeurContext = chauffeurContext;
            _adresContext = adresContext;
            _tankkaartContext = tankkaartContext;
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
            chauffeur = _chauffeurContext.Chauffeurs.FirstOrDefault(e => e.Id == command.Id);
            //if(chauffeur == null)
                //return not found
                //hoe doen met mediatr?

            //try catch rondzetten

            /*
            //1: delete adres
            var adres = chauffeur.Adres;
            chauffeur.Adres = null;
            //adres.Chauffeurs.Remove(chauffeur);

            _adresContext.BeginTransaction();
            await _adresContext.Delete(adres);
            await _adresContext.Commit();

            //2: delete tankkaart
            var tankkaart = chauffeur.Tankkaart;
            chauffeur.Tankkaart = null;
            //tankkaart.Chauffeurs.Remove(chauffeur);

            _tankkaartContext.BeginTransaction();
            await _tankkaartContext.Delete(tankkaart);
            await _tankkaartContext.Commit();

            */

            //3: delete chauffeur
            _chauffeurContext.BeginTransaction();
            await _chauffeurContext.Delete(chauffeur);
            await _chauffeurContext.Commit();

            //moet niets teruggeven
            //aanpassen
            //unit in mediatr equivalent van void

            return (int)command.Id;
        }
    }
}
