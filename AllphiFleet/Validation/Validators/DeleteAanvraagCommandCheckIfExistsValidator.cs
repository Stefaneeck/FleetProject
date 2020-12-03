using FluentValidation;
using Models;
using WriteRepositories;
using Commands.AanvraagCommands;

namespace Validation.Validators
{
    public class DeleteAanvraagCommandCheckIfExistsValidator : AbstractValidator<DeleteAanvraagCommand>
    {
        private readonly INHRepository<Aanvraag> _aanvraagContext;
        public DeleteAanvraagCommandCheckIfExistsValidator(INHRepository<Aanvraag> aanvraagContext)
        {
            _aanvraagContext = aanvraagContext;

            this.AddCheckIfExistsInDBValidator(_aanvraagContext);
        }
    }
}
