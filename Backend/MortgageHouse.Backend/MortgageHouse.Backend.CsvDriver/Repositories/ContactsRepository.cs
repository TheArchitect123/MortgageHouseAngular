﻿using MortgageHouse.Backend.CsvDriver.Services;
using MortgageHouse.Backend.Domain.Entities;
using MortgageHouse.Backend.Extensions;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace MortgageHouse.Backend.CsvDriver.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        public ContactsRepository(DatabaseCsvAccess dbService)
        {
            _dbService = dbService;
        }

        public DatabaseCsvAccess _dbService;

        public bool AddContact(Contact model)
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

        public IEnumerable<Contact> GetContacts()
        {
            try
            {
                return _dbService.GetItems().Select(w => w.ContactItem);
            }
            catch (Exception ex)
            {
                ex.HandleException();
                throw new FieldAccessException("Failed to persist address in the csv");
            }
        }

        public Contact GetContactForName(string name)
        {
            try
            {
                return _dbService.GetItems().Select(w => w.ContactItem).Where(w => w.FirstName.Equals(name)).SingleOrDefault();
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
