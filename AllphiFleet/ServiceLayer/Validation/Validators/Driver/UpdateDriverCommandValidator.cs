using Commands.DriverCommands;
using FluentValidation;

namespace Validation.Validators
{
    public class UpdateDriverCommandValidator : AbstractValidator<UpdateDriverCommand>
    {
        public UpdateDriverCommandValidator()
        {
            RuleFor(updateDriverCommand => updateDriverCommand.UpdateDriverDTO.Id).NotEmpty();
        }
    }
}
