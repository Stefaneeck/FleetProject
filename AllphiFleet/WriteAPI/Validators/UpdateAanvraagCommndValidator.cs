using FluentValidation;
using WriteAPI.Features.AanvraagFeatures;

namespace WriteAPI.Validators
{
    public class UpdateAanvraagCommndValidator : AbstractValidator<UpdateAanvraagCommand>
    {
        public UpdateAanvraagCommndValidator()
        {
            RuleFor(a => a.UpdateAanvraagDTO.Id).NotEmpty();
        }
    }
}
