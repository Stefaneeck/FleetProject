using AutoMapper;
using DTO;
using Models;

namespace ReadServices.Profiles
{
    //configuratie Automapper
    //moet overerven van profile klasse van automapper
    public class ChauffeurProfile : Profile
    {
        public ChauffeurProfile()
        {
            //omzetten van Chauffeur naar ChauffeurDTO
            this.CreateMap<Chauffeur, ChauffeurDTO>();

            //omgekeerde mapping
            this.CreateMap<Chauffeur, ChauffeurDTO>().ReverseMap();
        }
    }
}
