using Commands.FuelCardCommands;
using FluentValidation;

namespace Validation.Validators
{
    public class UpdateFuelCardCommandValidator : AbstractValidator<UpdateFuelCardCommand>
    {
        public UpdateFuelCardCommandValidator()
        {
            RuleFor(updateFuelCardCommand => updateFuelCardCommand.UpdateFuelCardDTO.Id).NotEmpty();
        }
    }
}
