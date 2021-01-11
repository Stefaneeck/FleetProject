using DTO;
using Models;
using AutoMapper;

namespace ReadServices.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            this.CreateMap<Address, AddressDTO>();
            this.CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
