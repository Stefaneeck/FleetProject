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
        public CreateChauffeurDTO CreateChauffeurDTO { get; set; }
    }
}
