using AutoMapper;
using DTO;
using Models;

namespace ReadServices.Profiles
{
    class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            this.CreateMap<Vehicle, VehicleDTO>();
            this.CreateMap<Vehicle, Vehicle>().ReverseMap();
        }
     
    }
}
