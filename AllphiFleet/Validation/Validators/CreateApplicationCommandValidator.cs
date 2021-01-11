using FluentValidation;
using Commands.ApplicationCommands;

namespace Validation.Validators
{
    public class CreateApplicationCommandValidator : AbstractValidator<CreateApplicationCommand>
    {
        public CreateApplicationCommandValidator()
        {
            RuleFor(a => a.CreateApplicationDTO.ApplicationDate).NotEmpty();
            RuleFor(a => a.CreateApplicationDTO.PossibleDates).NotEmpty();
            RuleFor(a => a.CreateApplicationDTO.ApplicationStatus).IsInEnum();
            RuleFor(a => a.CreateApplicationDTO.ApplicationType).IsInEnum();
            RuleFor(a => a.CreateApplicationDTO.Vehicle.Id).NotEmpty();
        }
    }
}
