using FluentValidation;
using WriteAPI.Features.AdresFeatures;

namespace WriteAPI.Validators
{
    public class CreateAdresCommndValidator : AbstractValidator<CreateAdresCommand>
    {
        public CreateAdresCommndValidator()
        {
            RuleFor(c => c.CreateAdresDTO.Straat).NotEmpty();
            RuleFor(c => c.CreateAdresDTO.Nummer).NotEmpty();
            RuleFor(c => c.CreateAdresDTO.Postcode).NotEmpty();
            RuleFor(c => c.CreateAdresDTO.Stad).NotEmpty();
        }
    }
}
