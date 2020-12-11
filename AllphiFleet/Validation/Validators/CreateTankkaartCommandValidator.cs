using FluentValidation;
using Commands.TankkaartCommands;

namespace Validation.Validators
{
    //validatie met fluentvalidation package
    //We have n number of similar validators for each command
    public class CreateTankkaartCommandValidator : AbstractValidator<CreateTankkaartCommand>
    {
        public CreateTankkaartCommandValidator()
        {
            RuleFor(c => c.CreateTankkaartDTO.Kaartnummer).NotEmpty();
            RuleFor(c => c.CreateTankkaartDTO.Pincode).NotEmpty();
            RuleFor(c => c.CreateTankkaartDTO.AuthType).IsInEnum();
            RuleFor(c => c.CreateTankkaartDTO.GeldigheidsDatum).NotEmpty();
            RuleFor(c => c.CreateTankkaartDTO.Opties).NotEmpty();
        }
    }
}
