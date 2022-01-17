using FluentValidation;
using Commands.ApplicationCommands;

namespace Validation.Validators
{
    public class CreateApplicationCommandValidator : AbstractValidator<CreateApplicationCommand>
    {
        public CreateApplicationCommandValidator()
        {
            RuleFor(a => a.CreateApplicationDTO.ApplicationDate).NotEmpty();
            RuleFor(a => a.CreateApplicationDTO.PossibleDate1).NotEmpty();
            RuleFor(a => a.CreateApplicationDTO.PossibleDate2).NotEmpty();
            RuleFor(a => a.CreateApplicationDTO.ApplicationStatus).IsInEnum();
            RuleFor(a => a.CreateApplicationDTO.ApplicationType).IsInEnum();
            RuleFor(a => a.CreateApplicationDTO.VehicleId).NotEmpty();
            RuleFor(a => a.CreateApplicationDTO.DriverEmail).NotEmpty()
                .Unless(a => a.CreateApplicationDTO.DriverEmail == null);
            //not working
            // RuleFor(a => a.CreateApplicationDTO.DriverId).NotEmpty()
              //  .Unless(a => a.CreateApplicationDTO.DriverId == null);
        }
    }
}
