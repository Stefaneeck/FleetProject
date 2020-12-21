using FluentValidation;
using Commands.ChauffeurCommands;

namespace Validation.Validators
{
    //validatie met fluentvalidation package
    //We have n number of similar validators for each command
    public class CreateChauffeurCommandValidator : AbstractValidator<CreateChauffeurCommand>
    {
        public CreateChauffeurCommandValidator()
        {
            RuleFor(c => c.CreateChauffeurDTO.Naam).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.Voornaam).NotEmpty();
            //is niet goed, want notempty bij boolean dan is het enkel ok als het true is
            //RuleFor(c => c.CreateChauffeurDTO.Actief).NotEmpty();
            //onnodig, als hij een andere waarde doorkrijgt dan faalt hij al op een eerder moment
            //RuleFor(c => c.CreateChauffeurDTO.Actief).Must(actief => actief == false || actief == true);
            RuleFor(c => c.CreateChauffeurDTO.GeboorteDatum).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.RijksRegisterNummer).NotEmpty();
            RuleFor(c => c.CreateChauffeurDTO.TypeRijbewijs).IsInEnum();
            RuleFor(c => c.CreateChauffeurDTO.Tankkaart.AuthType).IsInEnum();
        }
    }
}
