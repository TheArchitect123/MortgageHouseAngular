using AutoMapper;
using MortgageHouse.Backend.Domain.Entities;
using MortgageHouse.Backend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageHouse.Backend.Services.Business
{
    public class ContactUnionAddressService
    {
        public ContactUnionAddressService(IAddressRepository addressRepo, IContactsRepository contactRepo, IMapper mapper)
        {
            _mapper = mapper;
            _contactRepo = contactRepo;
            _addressRepo = addressRepo;
        }

        private readonly IAddressRepository _addressRepo;
        private readonly IContactsRepository _contactRepo;
        private readonly IMapper _mapper;

        public void WriteUnionForSpecifiedItem(ContactAddressDto unionDto)
        {
            //Write the address information & Contact information as a new record
            _addressRepo.AddAddress(_mapper.Map<AddressDto, Address>(unionDto.AddressItem));
            _contactRepo.AddContact(_mapper.Map<ContactDto, Contact>(unionDto.ContactItem));
        }

    }
}
