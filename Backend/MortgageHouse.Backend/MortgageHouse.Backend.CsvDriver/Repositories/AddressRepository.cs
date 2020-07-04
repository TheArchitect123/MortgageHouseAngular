using MortgageHouse.Backend.Constants;
using MortgageHouse.Backend.Domain.Entities;
using MortgageHouse.Backend.Extensions;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace MortgageHouse.Backend.CsvDriver.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public AddressRepository(ContentDb dbService)
        {
            _dbService = dbService;
        }

        public ContentDb _dbService;

        public bool AddAddress(Address model)
        {
            try
            {
                _dbService.sAddresses.Add(model);
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
                return null;
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
            try { _dbService.SaveChanges(); }
            catch { return false; }

            return true;
        }
    }
}
