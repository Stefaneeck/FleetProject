using AutoMapper;
using DTO;
using Models;

namespace ReadServices.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            this.CreateMap<Application, ApplicationDTO>();
            this.CreateMap<Application, ApplicationDTO>().ReverseMap();
        }
    }
}
