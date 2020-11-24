using FluentValidation;
using WriteAPI.Features.AanvraagFeatures;
using WriteAPI.Features.ChauffeurFeatures;

namespace WriteAPI.Validators
{
    //validatie met fluentvalidation package
    //We have n number of similar validators for each command
    public class CreateAanvraagCommndValidator : AbstractValidator<CreateAanvraagCommand>
    {
        //voor later
        //checken of al iets bestaat door dbcontext te injecteren bvb.
        public CreateAanvraagCommndValidator()
        {
            RuleFor(a => a.DatumAanvraag).NotEmpty();
            RuleFor(a => a.GewensteData).NotEmpty();
            RuleFor(a => a.StatusAanvraag).NotEmpty();
            RuleFor(a => a.TypeAanvraag).NotEmpty();
            RuleFor(a => a.VoertuigId).NotEmpty();
        }
    }
}
