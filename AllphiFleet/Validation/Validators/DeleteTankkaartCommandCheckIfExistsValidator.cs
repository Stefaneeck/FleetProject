using FluentValidation;
using Models;
using WriteRepositories;
using Commands.TankkaartCommands;

namespace Validation.Validators
{
    public class DeleteTankkaartCommandCheckIfExistsValidator : AbstractValidator<DeleteTankkaartCommand>
    {
        private readonly INHRepository<Tankkaart> _tankkaartContext;
        public DeleteTankkaartCommandCheckIfExistsValidator(INHRepository<Tankkaart> tankkaartContext)
        {
            _tankkaartContext = tankkaartContext;

            //niet nodig, standaard return 405 not allowed zonder id parameter
            //RuleFor(c => c.Id).NotEmpty();

            //is dit de goede manier of beter in controller?

            this.AddCheckIfExistsInDBValidator(_tankkaartContext);
            //als het zou aangeroepen worden zonder extension, klassieke static manier
            //ValidationExtensions.AddCheckIfExistsInDBValidator(this, _tankkaartContext);

        }
    }
}
