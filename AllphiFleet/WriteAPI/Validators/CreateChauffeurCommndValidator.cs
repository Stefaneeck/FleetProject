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
            
            RuleFor(c => c.CreateChauffeurDTO.Naam).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.Voornaam).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.Actief).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.GeboorteDatum).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.RijksRegisterNummer).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.TypeRijbewijs).NotEmpty();
            

            /*
            RuleFor(c => c.Naam).NotEmpty();
            RuleFor(c => c.Voornaam).NotEmpty();
            RuleFor(c => c.Actief).NotEmpty();
            RuleFor(c => c.GeboorteDatum).NotEmpty();
            RuleFor(c => c.RijksRegisterNummer).NotEmpty();
            RuleFor(c => c.TypeRijbewijs).NotEmpty();
            */

            //RuleFor(c => c.createChauffeurDTO.AdresId).NotEmpty();
            //RuleFor(c => c.createChauffeurDTO.Adres).NotEmpty();
            //RuleFor(c => c.createChauffeurDTO.TankkaartId).NotEmpty();
            //RuleFor(c => c.createChauffeurDTO.Tankkaart).NotEmpty();

        }
    }
}
