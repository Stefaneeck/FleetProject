using Commands.VehicleCommands;
using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.VehicleHandlers
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, Unit>
    {
        private readonly INHRepository<Vehicle> _context;

        public UpdateVehicleCommandHandler(INHRepository<Vehicle> context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateVehicleCommand command, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle
            {
                Id = command.UpdateVehicleDTO.Id,
                ChassisNr = command.UpdateVehicleDTO.ChassisNr,
                FuelType = command.UpdateVehicleDTO.FuelType,
                VehicleType = command.UpdateVehicleDTO.VehicleType,
                Mileage = command.UpdateVehicleDTO.Mileage
            };

            _context.BeginTransaction();

            try
            {
                await _context.Update(vehicle);
                await _context.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                await _context.Rollback();
            }

            return Unit.Value;
        }
    }
}
