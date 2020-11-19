using DTO;
using Models;
using AutoMapper;

namespace Services.Profiles
{
    public class TankkaartProfile : Profile
    {
        public TankkaartProfile()
        {
            //omzetten van Chauffeur naar ChauffeurDTO
            this.CreateMap<Tankkaart, TankkaartDTO>();

            //omgekeerde mapping
            this.CreateMap<Tankkaart, TankkaartDTO>().ReverseMap();
        }
    }
}
