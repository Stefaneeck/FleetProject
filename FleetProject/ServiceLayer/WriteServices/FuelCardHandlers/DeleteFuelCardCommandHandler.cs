using Commands.FuelCardCommands;
using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.FuelCardHandlers
{
    public class DeleteFuelCardCommandHandler : IRequestHandler<DeleteFuelCardCommand, Unit>
    {
        private readonly INHRepository<FuelCard> _fuelCardContext;
        public DeleteFuelCardCommandHandler(INHRepository<FuelCard> fuelCardContext)
        {
            _fuelCardContext = fuelCardContext;
        }
        public async Task<Unit> Handle(DeleteFuelCardCommand command, CancellationToken cancellationToken)
        {
            //fuelcard from db
            var fuelCard = new FuelCard();
            fuelCard = _fuelCardContext.FuelCards.FirstOrDefault(t => t.Id == command.Id);

            _fuelCardContext.BeginTransaction();

            try
            {
                await _fuelCardContext.Delete(fuelCard);
                await _fuelCardContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _fuelCardContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
