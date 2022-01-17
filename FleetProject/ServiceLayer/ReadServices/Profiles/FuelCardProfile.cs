using DTO;
using Models;
using AutoMapper;

namespace ReadServices.Profiles
{
    public class FuelCardProfile : Profile
    {
        public FuelCardProfile()
        {
            this.CreateMap<FuelCard, FuelCardDTO>();
            this.CreateMap<FuelCard, FuelCardDTO>().ReverseMap();
        }
    }
}
