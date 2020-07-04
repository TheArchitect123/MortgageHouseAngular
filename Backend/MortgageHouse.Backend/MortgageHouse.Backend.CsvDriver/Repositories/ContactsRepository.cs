using MortgageHouse.Backend.Domain.Entities;
using MortgageHouse.Backend.Extensions;

using System;
using System.Linq;

namespace MortgageHouse.Backend.CsvDriver.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        public ContactsRepository(ContentDb dbService)
        {
            _dbService = dbService;
        }

        public ContentDb _dbService;

        public bool AddContact(Contact model)
        {
            try
            {
              //  _dbService.Insert<Contact>(model);
            }
            catch (Exception ex)
            {
                ex.HandleException();
                throw new FieldAccessException("Failed to persist address in the csv");
            }

            return true;
        }

        public IQueryable<Contact> GetContacts()
        {
            try
            {
              //  return _dbService.GetAllItems<Contact>().AsQueryable();
            }
            catch (Exception ex)
            {
                ex.HandleException();
                throw new FieldAccessException("Failed to persist address in the csv");
            }

            return null;
        }

        public Contact GetContactForName(string name)
        {
            try
            {

                return null;
            }
            catch (Exception ex)
            {
                ex.HandleException();
                throw new FieldAccessException("Failed to persist address in the csv");
            }
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
