using FluentValidation;
using Commands.AddressCommands;

namespace Validation.Validators
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator()
        {
            RuleFor(updateAddressCommand => updateAddressCommand.UpdateAddressDTO.Id).NotEmpty();
        }
    }
}
