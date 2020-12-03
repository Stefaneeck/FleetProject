using FluentValidation;
using Commands.AdresCommands;

namespace Validation.Validators
{
    public class UpdateAdresCommandValidator : AbstractValidator<UpdateAdresCommand>
    {
        public UpdateAdresCommandValidator()
        {
            RuleFor(a => a.UpdateAdresDTO.Id).NotEmpty();
        }
    }
}
