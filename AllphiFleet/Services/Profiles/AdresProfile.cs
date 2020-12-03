using DTO;
using Models;
using AutoMapper;

namespace ReadServices.Profiles
{
    public class AdresProfile : Profile
    {
        public AdresProfile()
        {
            this.CreateMap<Adres, AdresDTO>();

            this.CreateMap<Adres, AdresDTO>().ReverseMap();
        }
    }
}
