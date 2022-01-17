using DTO;
using Models;
using AutoMapper;

namespace ReadServices.Profiles
{
    public class MaintenanceProfile : Profile
    {
        public MaintenanceProfile()
        {
            this.CreateMap<Maintenance, MaintenanceDTO>();
            this.CreateMap<Maintenance, MaintenanceDTO>().ReverseMap();
        }
    }
}
