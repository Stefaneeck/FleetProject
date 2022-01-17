using FluentValidation;
using Models;
using WriteRepositories;
using Commands.VehicleCommands;

namespace Validation.Validators
{
    public class DeleteVehicleCommandCheckIfExistsValidator : AbstractValidator<DeleteVehicleCommand>
    {
        private readonly INHRepository<Vehicle> _vehicleContext;
        public DeleteVehicleCommandCheckIfExistsValidator(INHRepository<Vehicle> vehicleContext)
        {
            _vehicleContext = vehicleContext;
            this.AddCheckIfIdExistsInDBValidator(_vehicleContext);
        }
    }
}
