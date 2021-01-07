using FluentValidation;
using Commands.FuelCardCommands;

namespace Validation.Validators
{
    //validatie met fluentvalidation package
    //We have n number of similar validators for each command
    public class CreateFuelCardCommandValidator : AbstractValidator<CreateFuelCardCommand>
    {
        public CreateFuelCardCommandValidator()
        {
            RuleFor(c => c.CreateFuelCardDTO.CardNumber).NotEmpty();
            RuleFor(c => c.CreateFuelCardDTO.Pincode).NotEmpty();
            RuleFor(c => c.CreateFuelCardDTO.AuthType).IsInEnum();
            RuleFor(c => c.CreateFuelCardDTO.ValidUntilDate).NotEmpty();
            RuleFor(c => c.CreateFuelCardDTO.Options).NotEmpty();
        }
    }
}
