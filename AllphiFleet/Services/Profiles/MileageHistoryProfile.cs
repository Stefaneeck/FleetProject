using AutoMapper;
using DTO.MileageHistory;
using Models;

namespace ReadServices.Profiles
{
    class MileageHistoryProfile : Profile
    {
        public MileageHistoryProfile()
        {
            this.CreateMap<MileageHistory, MileageHistoryDTO>();
            this.CreateMap<MileageHistory, MileageHistoryDTO>().ReverseMap();
        }
    }
}
