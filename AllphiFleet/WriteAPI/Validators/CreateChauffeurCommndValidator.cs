using FluentValidation;
using WriteAPI.Features.ChauffeurFeatures;

namespace WriteAPI.Validators
{
    //validatie met fluentvalidation package
    //We have n number of similar validators for each command
    public class CreateChauffeurCommndValidator : AbstractValidator<CreateChauffeurCommand>
    {
        //voor later
        //checken of al iets bestaat door dbcontext te injecteren bvb.
        public CreateChauffeurCommndValidator()
        {
            RuleFor(c => c.createChauffeurDTO.Naam).NotEmpty();
            RuleFor(c => c.createChauffeurDTO.Voornaam).NotEmpty();
            RuleFor(c => c.createChauffeurDTO.Actief).NotEmpty();
            RuleFor(c => c.createChauffeurDTO.GeboorteDatum).NotEmpty();
            RuleFor(c => c.createChauffeurDTO.RijksRegisterNummer).NotEmpty();
            RuleFor(c => c.createChauffeurDTO.TypeRijbewijs).NotEmpty();
            //RuleFor(c => c.createChauffeurDTO.AdresId).NotEmpty();
            RuleFor(c => c.createChauffeurDTO.Adres).NotEmpty();
            //RuleFor(c => c.createChauffeurDTO.TankkaartId).NotEmpty();
            RuleFor(c => c.createChauffeurDTO.Tankkaart).NotEmpty();

        }
    }
}
