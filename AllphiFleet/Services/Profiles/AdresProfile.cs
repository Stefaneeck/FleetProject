using DTO;
using Models;
using AutoMapper;

namespace Services.Profiles
{
    public class AdresProfile : Profile
    {
        public AdresProfile()
        {
            //omzetten van Chauffeur naar ChauffeurDTO
            this.CreateMap<Adres, AdresDTO>();

            //omgekeerde mapping
            this.CreateMap<Adres, AdresDTO>().ReverseMap();
        }
    }
}
