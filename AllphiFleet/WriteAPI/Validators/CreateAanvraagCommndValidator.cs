using FluentValidation;
using WriteAPI.Features.AanvraagFeatures;

namespace WriteAPI.Validators
{
    public class CreateAanvraagCommndValidator : AbstractValidator<CreateAanvraagCommand>
    {
        public CreateAanvraagCommndValidator()
        {
            RuleFor(a => a.CreateAanvraagDTO.DatumAanvraag).NotEmpty();
            RuleFor(a => a.CreateAanvraagDTO.GewensteData).NotEmpty();
            RuleFor(a => a.CreateAanvraagDTO.StatusAanvraag).NotEmpty();
            RuleFor(a => a.CreateAanvraagDTO.TypeAanvraag).NotEmpty();
            RuleFor(a => a.CreateAanvraagDTO.Voertuig).NotEmpty();
        }
    }
}
