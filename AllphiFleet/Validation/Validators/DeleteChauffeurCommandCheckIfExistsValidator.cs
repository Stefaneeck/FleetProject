﻿using FluentValidation;
using Models;
using WriteRepositories;
using Commands.ChauffeurCommands;

namespace Validation.Validators
{
    public class DeleteChauffeurCommandCheckIfExistsValidator : AbstractValidator<DeleteChauffeurCommand>
    {
        private readonly INHRepository<Chauffeur> _chauffeurContext;
        public DeleteChauffeurCommandCheckIfExistsValidator(INHRepository<Chauffeur> chauffeurContext)
        {
            _chauffeurContext = chauffeurContext;

            //niet nodig, standaard return 405 not allowed zonder id parameter
            //RuleFor(c => c.Id).NotEmpty();

            //is dit de goede manier of beter in controller?

            //custom validator
            //checken of de chauffeur bestaat
            //generic extension van maken

            this.AddCheckIfExistsInDBValidator(_chauffeurContext);
            //als het zou aangeroepen worden zonder extension, klassieke static manier
            //ValidationExtensions.AddCheckIfExistsInDBValidator(this, _chauffeurContext);

            /*
            this.RuleFor(x => x.Id)
            .Must(id =>
            {
                var chauffeur = _chauffeurContext.Chauffeurs.FirstOrDefault(a => a.Id == id);
                return chauffeur != null;
            })
            .WithErrorCode("AlreadyExists")
            .WithMessage("Chauffeur bestaat niet.");
            */
        }
    }
}