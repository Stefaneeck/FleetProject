using Commands.TankkaartCommands;
using FluentValidation;

namespace Validation.Validators
{
    public class UpdateTankkaartCommandValidator : AbstractValidator<UpdateTankkaartCommand>
    {
        public UpdateTankkaartCommandValidator()
        {
            RuleFor(updateTankkaartCommand => updateTankkaartCommand.UpdateTankkaartDTO.Id).NotEmpty();
        }
    }
}
