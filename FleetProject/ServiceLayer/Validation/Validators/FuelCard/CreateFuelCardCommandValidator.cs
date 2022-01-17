using FluentValidation;
using Commands.FuelCardCommands;
using Models;
using WriteRepositories;
using System.Linq;

namespace Validation.Validators
{
    //validatie met fluentvalidation package
    //We have n number of similar validators for each command
    public class CreateFuelCardCommandValidator : AbstractValidator<CreateFuelCardCommand>
    {
        private readonly INHRepository<FuelCard> _fuelCardContext;

        public CreateFuelCardCommandValidator(INHRepository<FuelCard> fuelCardContext)
        {
            _fuelCardContext = fuelCardContext;

            RuleFor(command => command.CreateFuelCardDTO.CardNumber)
            .Must(cardNumber =>
            {
                var obj = _fuelCardContext.FuelCards.FirstOrDefault(fuelCard => fuelCard.CardNumber == cardNumber);
                return obj == null;
            })
            .WithErrorCode("AlreadyExists")
            .WithMessage("Fuelcard already exists.");

            RuleFor(c => c.CreateFuelCardDTO.CardNumber).NotEmpty();
            RuleFor(c => c.CreateFuelCardDTO.Pincode).NotEmpty();
            RuleFor(c => c.CreateFuelCardDTO.AuthType).IsInEnum();
            RuleFor(c => c.CreateFuelCardDTO.ValidUntilDate).NotEmpty();
            RuleFor(c => c.CreateFuelCardDTO.Options).NotEmpty();
            RuleFor(c => c.CreateFuelCardDTO.Active).Must(x => x == false || x == true);
        }
    }
}
