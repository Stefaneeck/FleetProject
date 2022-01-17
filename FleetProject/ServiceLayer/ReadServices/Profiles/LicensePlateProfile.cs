using AutoMapper;
using DTO.LicensePlate;
using Models;

namespace ReadServices.Profiles
{
    public class LicensePlateProfile : Profile
    {
        public LicensePlateProfile()
        {
            this.CreateMap<LicensePlate, LicensePlateDTO>();
            this.CreateMap<LicensePlateDTO, LicensePlate>().ReverseMap();
        }

    }
}
