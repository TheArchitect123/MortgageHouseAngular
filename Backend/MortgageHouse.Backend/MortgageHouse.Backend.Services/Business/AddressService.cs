using AutoMapper;
using MortgageHouse.Backend.Constants;
using MortgageHouse.Backend.CsvDriver.Services;
using MortgageHouse.Backend.Domain.Entities;
using MortgageHouse.Backend.Domain.ServiceArtifacts;
using MortgageHouse.Backend.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

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

        public AddressDto GetAddressForSpecifiedName(string streetName)
        {
            var addressItem = _commonRepo.GetAddressForID(streetName);
            return addressItem == null ? throw new ArgumentNullException("Could not find the specified addresss") : _mapper.Map<Address, AddressDto>(addressItem);
        }

        public IEnumerable<AddressDto> GetAllAddresses()
        {
            var addressItems = _commonRepo.GetAddresses();
            return addressItems == null ? throw new ArgumentNullException("Could not find any addresses") : addressItems.ToList().ConvertAll(w => _mapper.Map<Address, AddressDto>(w));
        }

        public void WriteAddressForSpecifiedItem(AddressDto addressDto)
        {
            _commonRepo.AddAddress(_mapper.Map<AddressDto, Address>(addressDto));
        }

        public async Task WriteAddressForSpecifiedItemAsync(AddressDto addressDto)
        {
            _commonRepo.AddAddress(_mapper.Map<AddressDto, Address>(addressDto));
        }
    }
}
