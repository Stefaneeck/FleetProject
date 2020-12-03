using DTO;
using Models;
using AutoMapper;

namespace ReadServices.Profiles
{
    public class FactuurProfile : Profile
    {
        public FactuurProfile()
        {
            this.CreateMap<Factuur, FactuurDTO>();

            this.CreateMap<Factuur, FactuurDTO>().ReverseMap();
        }
    }
}
