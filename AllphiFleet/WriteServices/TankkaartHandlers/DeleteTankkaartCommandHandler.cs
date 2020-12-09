using Commands.TankkaartCommands;
using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.TankkaartHandlers
{
    public class DeleteTankkaartCommandHandler : IRequestHandler<DeleteTankkaartCommand, Unit>
    {
        private readonly INHRepository<Tankkaart> _tankkaartContext;
        public DeleteTankkaartCommandHandler(INHRepository<Tankkaart> tankkaartContext)
        {
            _tankkaartContext = tankkaartContext;
        }
        public async Task<Unit> Handle(DeleteTankkaartCommand command, CancellationToken cancellationToken)
        {
            //chauffeur ophalen
            var tankkaart = new Tankkaart();
            tankkaart = _tankkaartContext.Tankkaarten.FirstOrDefault(t => t.Id == command.Id);

            _tankkaartContext.BeginTransaction();

            try
            {
                await _tankkaartContext.Delete(tankkaart);
                await _tankkaartContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _tankkaartContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
