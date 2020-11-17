using AutoMapper;
using DTO;
using Models;

namespace Services.Profiles
{
    //configuratie Automapper
    public class AanvraagProfile : Profile
    {
        public AanvraagProfile()
        {
            this.CreateMap<Aanvraag, AanvraagDTO>();

            this.CreateMap<Aanvraag, AanvraagDTO>().ReverseMap();
        }
    }
}
