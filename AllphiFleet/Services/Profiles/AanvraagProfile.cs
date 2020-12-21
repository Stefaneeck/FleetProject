using AutoMapper;
using DTO;
using Models;

namespace ReadServices.Profiles
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
