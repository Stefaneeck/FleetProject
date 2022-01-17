using FluentValidation;
using Commands.AddressCommands;

namespace Validation.Validators
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(c => c.CreateAddressDTO.Street).NotEmpty();
            RuleFor(c => c.CreateAddressDTO.Number).NotEmpty();
            RuleFor(c => c.CreateAddressDTO.Zipcode).NotEmpty();
            RuleFor(c => c.CreateAddressDTO.City).NotEmpty();
        }
    }
}
