using FluentValidation;
using Models;
using System.Linq;
using WriteAPI.DataLayer.Repositories;
using WriteAPI.Features.ChauffeurFeatures;

namespace WriteAPI.Validators
{
    public class DeleteChauffeurCommndCheckIfExistsValidator : AbstractValidator<DeleteChauffeurCommand>
    {
        private readonly INHRepository<Chauffeur> _chauffeurContext;
        public DeleteChauffeurCommndCheckIfExistsValidator(INHRepository<Chauffeur> chauffeurContext)
        {
            _chauffeurContext = chauffeurContext;

            //niet nodig, standaard return 405 not allowed zonder id parameter
            //RuleFor(c => c.Id).NotEmpty();

            //is dit de goede manier of beter in controller?

            //custom validator
            //checken of de chauffeur bestaat
            //generic extension van maken
            RuleFor(x => x.Id)
            .Must(id =>
            {
                var chauffeur = _chauffeurContext.Chauffeurs.FirstOrDefault(a => a.Id == id);
                return chauffeur != null;
            })
            .WithErrorCode("AlreadyExists")
            .WithMessage("Chauffeur bestaat niet.");
        }

    }
}
