using FluentValidation;
using WriteAPI.Features.ChauffeurFeatures;

namespace WriteAPI.Validators
{
    public class UpdateChauffeurCommndValidator : AbstractValidator<UpdateChauffeurCommand>
    {
        public UpdateChauffeurCommndValidator()
        {
            RuleFor(c => c.UpdateChauffeurDTO.Id).NotEmpty();
        }
    }
}
