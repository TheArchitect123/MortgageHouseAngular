using AutoMapper;
using MortgageHouse.Backend.Domain.Entities;
using MortgageHouse.Backend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageHouse.Backend.Services.Business
{
    public class ContactsService
    {
        //Dependency Injection is used when injecting services
        public ContactsService(IContactsRepository commonRepo, IMapper mapper)
        {
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        private readonly IContactsRepository _commonRepo;
        private readonly IMapper _mapper;

        public ContactDto GetContactForSpecifiedName(string firstName)
        {
            var contact = _commonRepo.GetContactForName(firstName);
            return contact == null ? throw new ArgumentNullException("Could not find the specified contact") : _mapper.Map<Contact, ContactDto>(contact);
        }

        public IEnumerable<ContactDto> GetAllContacts()
        {
            var contactsItems = _commonRepo.GetContacts();
            return contactsItems == null ? throw new ArgumentNullException("Could not find any contacts") : contactsItems.ToList().ConvertAll(w => _mapper.Map<Contact, ContactDto>(w));
        }

        public void WriteContactForSpecifiedItem(ContactDto contactDto)
        {
            _commonRepo.AddContact(_mapper.Map<ContactDto, Contact>(contactDto));
        }

        public async Task WriteContactForSpecifiedItemAsync(ContactDto contactDto)
        {
            _commonRepo.AddContact(_mapper.Map<ContactDto, Contact>(contactDto));
        }
    }
}
