using FluentValidation;
using Commands.ApplicationCommands;

namespace Validation.Validators
{
    public class UpdateApplicationCommandValidator : AbstractValidator<UpdateApplicationCommand>
    {
        public UpdateApplicationCommandValidator()
        {
            RuleFor(a => a.UpdateApplicationDTO.Id).NotEmpty();
        }
    }
}
