using FluentValidation;
using Commands.VehicleCommands;

namespace Validation.Validators
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(c => c.CreateVehicleDTO.ChassisNr).NotEmpty();
            RuleFor(c => c.CreateVehicleDTO.FuelType).IsInEnum();
            RuleFor(c => c.CreateVehicleDTO.VehicleType).IsInEnum();
            RuleFor(c => c.CreateVehicleDTO.Mileage).NotEmpty();
        }
    }
}
