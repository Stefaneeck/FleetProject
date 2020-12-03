using FluentValidation;
using Commands.AdresCommands;

namespace Validation.Validators
{
    public class CreateAdresCommandValidator : AbstractValidator<CreateAdresCommand>
    {
        public CreateAdresCommandValidator()
        {
            RuleFor(c => c.CreateAdresDTO.Straat).NotEmpty();
            RuleFor(c => c.CreateAdresDTO.Nummer).NotEmpty();
            RuleFor(c => c.CreateAdresDTO.Postcode).NotEmpty();
            RuleFor(c => c.CreateAdresDTO.Stad).NotEmpty();
        }
    }
}
