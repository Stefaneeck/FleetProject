using FluentValidation;
using Models;
using WriteAPI.Features.ChauffeurFeatures;

namespace WriteAPI.Validators
{
    //validatie met fluentvalidation package
    public class CreateChauffeurCommndValidator : AbstractValidator<CreateChauffeurCommand>
    {
        //voor later
        //checken of al iets bestaat door dbcontext te injecteren bvb.
        public CreateChauffeurCommndValidator()
        {
            RuleFor(c => c.Naam).NotEmpty();
            RuleFor(c => c.Voornaam).NotEmpty();
        }
    }
}
