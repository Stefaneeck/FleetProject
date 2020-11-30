using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteAPI.DataLayer.Repositories;

namespace WriteAPI.Features.ChauffeurFeatures
{
    public class DeleteChauffeurCommandHandler : IRequestHandler<DeleteChauffeurCommand, Unit>
    {
        private readonly INHRepository<Chauffeur> _chauffeurContext;
        public DeleteChauffeurCommandHandler(INHRepository<Chauffeur> chauffeurContext)
        {
            _chauffeurContext = chauffeurContext;
        }
        public async Task<Unit> Handle(DeleteChauffeurCommand command, CancellationToken cancellationToken)
        {
            //chauffeur ophalen
            var chauffeur = new Chauffeur();
            chauffeur = _chauffeurContext.Chauffeurs.FirstOrDefault(e => e.Id == command.Id);

            _chauffeurContext.BeginTransaction();

            try
            {
                await _chauffeurContext.Delete(chauffeur);
                await _chauffeurContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _chauffeurContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
