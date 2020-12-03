using FluentValidation;
using Commands.ChauffeurCommands;

namespace Validation.Validators
{
    //validatie met fluentvalidation package
    //We have n number of similar validators for each command
    public class CreateChauffeurCommandValidator : AbstractValidator<CreateChauffeurCommand>
    {
        //voor later
        //checken of al iets bestaat door dbcontext te injecteren bvb.
        public CreateChauffeurCommandValidator()
        {
            RuleFor(c => c.CreateChauffeurDTO.Naam).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.Voornaam).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.Actief).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.GeboorteDatum).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.RijksRegisterNummer).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.TypeRijbewijs).NotEmpty();

            //RuleFor(c => c.createChauffeurDTO.Adres).NotEmpty();
            //RuleFor(c => c.createChauffeurDTO.Tankkaart).NotEmpty();
        }
    }
}
