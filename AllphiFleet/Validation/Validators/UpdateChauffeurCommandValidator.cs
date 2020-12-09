using Commands.ChauffeurCommands;
using FluentValidation;

namespace Validation.Validators
{
    public class UpdateChauffeurCommandValidator : AbstractValidator<UpdateChauffeurCommand>
    {
        public UpdateChauffeurCommandValidator()
        {
            RuleFor(updateChauffeurCommand => updateChauffeurCommand.UpdateChauffeurDTO.Id).NotEmpty();
        }
    }
}
