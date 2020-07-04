using AutoMapper;
using MortgageHouse.Backend.Constants;
using MortgageHouse.Backend.Domain.Entities;
using MortgageHouse.Backend.Domain.ServiceArtifacts;
using MortgageHouse.Backend.Dto;

namespace MortgageHouse.Backend.Services.Business
{
    public class AddressService
    {
        //Dependency Injection is used when injecting services
        public AddressService(IAddressRepository commonRepo, IMapper mapper)
        {
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        private readonly IAddressRepository _commonRepo;
        private readonly IMapper _mapper;


        public AddressDto GetAddressForSpecifiedName(string fullName)
        {
            return null;
        }

        public bool WriteAddressForSpecifiedItem(AddressDto addressDto)
        {
            _commonRepo.SaveChanges

        }
    }
}
