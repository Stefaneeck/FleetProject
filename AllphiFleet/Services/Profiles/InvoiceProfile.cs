using DTO;
using Models;
using AutoMapper;

namespace ReadServices.Profiles
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            this.CreateMap<Invoice, InvoiceDTO>();
            this.CreateMap<Invoice, InvoiceDTO>().ReverseMap();
        }
    }
}
