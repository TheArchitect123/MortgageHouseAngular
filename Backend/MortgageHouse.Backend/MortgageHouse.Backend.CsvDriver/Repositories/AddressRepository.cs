using MortgageHouse.Backend.Constants;
using MortgageHouse.Backend.CsvDriver.Services;
using MortgageHouse.Backend.Domain.Entities;
using MortgageHouse.Backend.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace MortgageHouse.Backend.CsvDriver.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public AddressRepository(DatabaseCsvAccess dbService)
        {
            _dbService = dbService;
        }

        public DatabaseCsvAccess _dbService;

        public bool AddAddress(Address model)
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

        public IEnumerable<Address> GetAddresses()
        {
            try
            {
                return _dbService.GetItems().Select(w => w.AddressItem);
            }
            catch (Exception ex)
            {
                ex.HandleException();
                throw new FieldAccessException("Failed to persist address in the csv");
            }
        }

        public Address GetAddressForID(string streetName)
        {
            try
            {
                return _dbService.GetItems().Select(w => w.AddressItem).Where(w => w.StreetName.Equals(streetName, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
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
