using AutoMapper;
using DTO;
using Models;

namespace ReadServices.Profiles
{
    //configuration Automapper, must inherit from Profile class
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            this.CreateMap<Driver, DriverDTO>();
            this.CreateMap<Driver, DriverDTO>().ReverseMap();
        }
    }
}
