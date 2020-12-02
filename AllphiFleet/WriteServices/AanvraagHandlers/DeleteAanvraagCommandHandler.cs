using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteAPI.Features.AanvraagFeatures
{
    public class DeleteAanvraagCommandHandler : IRequestHandler<DeleteAanvraagCommand, Unit>
    {
        private readonly INHRepository<Aanvraag> _aanvraagContext;
        public DeleteAanvraagCommandHandler(INHRepository<Aanvraag> aanvraagContext)
        {
            _aanvraagContext = aanvraagContext;
        }

        public async Task<Unit> Handle(DeleteAanvraagCommand command, CancellationToken cancellationToken)
        {
            var aanvraag = _aanvraagContext.Aanvragen.FirstOrDefault(a => a.Id == command.Id);

            _aanvraagContext.BeginTransaction();

            try
            {
                await _aanvraagContext.Delete(aanvraag);
                await _aanvraagContext.Commit();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _aanvraagContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
