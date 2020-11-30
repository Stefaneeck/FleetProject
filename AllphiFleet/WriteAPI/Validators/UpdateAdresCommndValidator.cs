using FluentValidation;
using WriteAPI.Features.AdresFeatures;

namespace WriteAPI.Validators
{
    public class UpdateAdresCommndValidator : AbstractValidator<UpdateAdresCommand>
    {
        public UpdateAdresCommndValidator()
        {
            RuleFor(a => a.UpdateAdresDTO.Id).NotEmpty();
        }
    }
}
