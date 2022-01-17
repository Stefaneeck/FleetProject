using FluentValidation;
using Commands.VehicleCommands;

namespace Validation.Validators
{
    public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
    {
        public UpdateVehicleCommandValidator()
        {
            RuleFor(c => c.UpdateVehicleDTO.Id).NotEmpty();
        }
    }
}
