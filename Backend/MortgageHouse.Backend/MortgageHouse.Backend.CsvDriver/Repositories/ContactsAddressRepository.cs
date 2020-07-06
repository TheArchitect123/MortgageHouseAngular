using MortgageHouse.Backend.CsvDriver.Services;
using MortgageHouse.Backend.Domain.Entities;
using MortgageHouse.Backend.Extensions;

using System;
using System.Collections.Generic;

namespace MortgageHouse.Backend.CsvDriver.Repositories
{
    public class ContactsAddressRepository : IContactsAddressRepository
    {
        public ContactsAddressRepository(DatabaseCsvAccess dbService)
        {
            _dbService = dbService;
        }

        public DatabaseCsvAccess _dbService;

        public bool AddContactAddress(ContactAddress model)
        {
            try
            {
                _dbService.Insert(model);
            }
            catch (Exception ex)
            {
                ex.HandleException();
                throw new FieldAccessException("Failed to persist address in the csv");
            }

            return true;
        }

        public IEnumerable<ContactAddress> GetContactAddresses()
        {
            try
            {
                return _dbService.GetItems();
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
