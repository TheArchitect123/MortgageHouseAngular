﻿using MortgageHouse.Backend.CsvDriver.Services;
using MortgageHouse.Backend.Domain.Entities;
using MortgageHouse.Backend.Extensions;

using System;
using System.Linq;

namespace MortgageHouse.Backend.CsvDriver.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public AddressRepository(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public DatabaseService _dbService;

        public bool AddAddress(Address model)
        {
            try
            {
                _dbService.Insert<Address>(model);
            }
            catch (Exception ex)
            {
                ex.HandleException();
                throw new FieldAccessException("Failed to persist address in the csv");
            }

            return true;
        }

        public IQueryable<Address> GetAddresses()
        {
            try
            {
                return _dbService.GetAllItems<Address>().AsQueryable();
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
                return _dbService.GetAllItems<Address>().SingleOrDefault(w => w.StreetName.Equals(streetName, StringComparison.OrdinalIgnoreCase));
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
