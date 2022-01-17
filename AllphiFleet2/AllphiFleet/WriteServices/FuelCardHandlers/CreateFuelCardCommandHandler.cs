using Commands.FuelCardCommands;
using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.FuelCardHandlers
{
    public class CreateFuelCardCommandHandler : IRequestHandler<CreateFuelCardCommand, int>
    {
        private readonly INHRepository<FuelCard> _context;

        public CreateFuelCardCommandHandler(INHRepository<FuelCard> context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateFuelCardCommand command, CancellationToken cancellationToken)
        {
            var fuelCard = new FuelCard
            {
                AuthType = command.CreateFuelCardDTO.AuthType,
                ValidUntilDate = command.CreateFuelCardDTO.ValidUntilDate,
                CardNumber = command.CreateFuelCardDTO.CardNumber,
                Options = command.CreateFuelCardDTO.Options,
                Pincode = command.CreateFuelCardDTO.Pincode,
                Active = command.CreateFuelCardDTO.Active
            };

            _context.BeginTransaction();

            try
            {
                await _context.Save(fuelCard);
                await _context.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _context.Rollback();
            }

            return (int)fuelCard.Id;
        }
    }
}
