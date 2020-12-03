using FluentValidation;
using Commands.AanvraagCommands;

namespace Validation.Validators
{
    public class UpdateAanvraagCommandValidator : AbstractValidator<UpdateAanvraagCommand>
    {
        public UpdateAanvraagCommandValidator()
        {
            RuleFor(a => a.UpdateAanvraagDTO.Id).NotEmpty();
        }
    }
}
