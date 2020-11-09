using AutoMapper;
using DTO;
using Repositories.Models;

namespace Repositories.Profiles
{
    //moet overerven van profile klasse van automapper
    public class ChauffeurProfile : Profile
    {
        public ChauffeurProfile()
        {
            //omzetten van Chauffeur naar ChauffeurDTO
            this.CreateMap<Chauffeur, ChauffeurDTO>();
        }
    }
}
