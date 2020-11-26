using DTO;
using MediatR;
using Models;
using Models.Enums;
using System;

namespace WriteAPI.Features.ChauffeurFeatures
{
    //mag dto zijn?
    public class CreateChauffeurCommand : IRequest<int>
    {
        /*
        public long Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        //todo validatie
        public string RijksRegisterNummer { get; set; }
        public RijbewijsTypes TypeRijbewijs { get; set; }
        public bool Actief { get; set; }
        public Adres Adres { get; set; }
        public long AdresId { get; set; }
        public virtual long TankkaartId { get; set; }

        */
        public CreateChauffeurDTO CreateChauffeurDTO { get; set; }
        //per command een DTO maken, verschillende DTOs maken
    }
}
