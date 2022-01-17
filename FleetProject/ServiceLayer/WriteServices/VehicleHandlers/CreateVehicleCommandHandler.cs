using Commands.VehicleCommands;
using MediatR;
using Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using WriteRepositories;

namespace WriteServices.VehicleHandlers
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, int>
    {
        private readonly INHRepository<Vehicle> _context;

        public CreateVehicleCommandHandler(INHRepository<Vehicle> context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateVehicleCommand command, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle
            {
                Id = 0,
                ChassisNr = command.CreateVehicleDTO.ChassisNr,
                FuelType = command.CreateVehicleDTO.FuelType,
                VehicleType = command.CreateVehicleDTO.VehicleType,
                Mileage = command.CreateVehicleDTO.Mileage
            };

            _context.BeginTransaction();

            try
            {
                await _context.Save(vehicle);
                await _context.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                await _context.Rollback();
            }

            return (int)vehicle.Id;
        }
    }
}
