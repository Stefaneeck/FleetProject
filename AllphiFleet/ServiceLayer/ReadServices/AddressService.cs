using AutoMapper;
using DTO;
using ReadRepositories;
using Models;
using System.Collections.Generic;
using System.Linq;
using ReadServices.Interfaces;

namespace ReadServices
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IDataReadRepository<Address> _repository;
        public AddressService(IMapper mapper, IDataReadRepository<Address> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<AddressDTO> GetAddresses()
        {
            var results = _repository.GetAll();
            return _mapper.Map<IEnumerable<AddressDTO>>(results.ToList());
        }

        public AddressDTO GetAddress(long id)
        {
            return _mapper.Map<AddressDTO>(_repository.Get(id));
        }
    }
}
