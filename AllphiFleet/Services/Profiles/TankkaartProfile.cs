using DTO;
using Models;
using AutoMapper;

namespace ReadServices.Profiles
{
    public class TankkaartProfile : Profile
    {
        public TankkaartProfile()
        {
            this.CreateMap<Tankkaart, TankkaartDTO>();
            this.CreateMap<Tankkaart, TankkaartDTO>().ReverseMap();
        }
    }
}
