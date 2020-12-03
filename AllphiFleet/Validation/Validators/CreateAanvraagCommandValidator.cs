using FluentValidation;
using Commands.AanvraagCommands;

namespace Validation.Validators
{
    public class CreateAanvraagCommandValidator : AbstractValidator<CreateAanvraagCommand>
    {
        public CreateAanvraagCommandValidator()
        {
            RuleFor(a => a.CreateAanvraagDTO.DatumAanvraag).NotEmpty();
            RuleFor(a => a.CreateAanvraagDTO.GewensteData).NotEmpty();
            RuleFor(a => a.CreateAanvraagDTO.StatusAanvraag).NotEmpty();
            RuleFor(a => a.CreateAanvraagDTO.TypeAanvraag).NotEmpty();
            RuleFor(a => a.CreateAanvraagDTO.Voertuig).NotEmpty();
        }
    }
}
