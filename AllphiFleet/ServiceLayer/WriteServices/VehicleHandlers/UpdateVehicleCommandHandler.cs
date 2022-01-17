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
        private readonly INHRepository<Vehicle> _vehicleContext;
        private readonly INHRepository<MileageHistory> _mileageHistoryContext;

        public UpdateVehicleCommandHandler(INHRepository<Vehicle> vehicleContext, INHRepository<MileageHistory> mileageHistoryContext)
        {
            _vehicleContext = vehicleContext;
            _mileageHistoryContext = mileageHistoryContext;
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

            _vehicleContext.BeginTransaction();

            try
            {
                await _vehicleContext.Update(vehicle);
                await _vehicleContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                await _vehicleContext.Rollback();
            }

            //for mileage history
            var mileageHistory = new MileageHistory
            {
                Id = 0,
                VehicleId = command.UpdateVehicleDTO.Id,
                Date = DateTime.Now,
                Mileage = command.UpdateVehicleDTO.Mileage,   
            };

            _mileageHistoryContext.BeginTransaction();

            try
            {
                await _mileageHistoryContext.Save(mileageHistory);
                await _mileageHistoryContext.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                await _mileageHistoryContext.Rollback();
            }

            return Unit.Value;
        }
    }
}
