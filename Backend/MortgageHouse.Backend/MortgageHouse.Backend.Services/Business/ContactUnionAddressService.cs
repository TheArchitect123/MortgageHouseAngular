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
        public ContactUnionAddressService(IContactsAddressRepository commonRepo, IMapper mapper)
        {
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        private readonly IContactsAddressRepository _commonRepo;
        private readonly IMapper _mapper;

        public void WriteUnionForSpecifiedItem(ContactAddressDto unionDto)
        {
            //Write the address information & Contact information as a new record
            _commonRepo.AddContactAddress(_mapper.Map<ContactAddressDto, ContactAddress>(unionDto));
        }

    }
}
