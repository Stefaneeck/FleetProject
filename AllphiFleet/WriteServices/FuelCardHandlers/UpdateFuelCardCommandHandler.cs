﻿using Commands.FuelCardCommands;
using MediatR;
using Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.FuelCardHandlers
{
    public class UpdateFuelCardCommandHandler : IRequestHandler<UpdateFuelCardCommand, Unit>
    {
        private readonly INHRepository<FuelCard> _fuelCardContext;
        public UpdateFuelCardCommandHandler(INHRepository<FuelCard> fuelCardContext)
        {
            _fuelCardContext = fuelCardContext;

        }
        public async Task<Unit> Handle(UpdateFuelCardCommand command, CancellationToken cancellationToken)
        {
            FuelCard tankkaartVanDB = _fuelCardContext.FuelCards.FirstOrDefault(t => t.Id == command.UpdateFuelCardDTO.Id);

            var tankkaart = new FuelCard
            {
                Id = command.UpdateFuelCardDTO.Id,
                AuthType = command.UpdateFuelCardDTO.AuthType,
                ValidUntilDate = command.UpdateFuelCardDTO.ValidUntilDate,
                CardNumber = command.UpdateFuelCardDTO.CardNumber,
                Options = command.UpdateFuelCardDTO.Options,
                Pincode = command.UpdateFuelCardDTO.Pincode
            };

            _fuelCardContext.BeginTransaction();

            try
            {
                await _fuelCardContext.Update(tankkaart);
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
