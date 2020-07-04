using MortgageHouse.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortgageHouse.Backend.CsvDriver.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        //Write the data to the Csv

        public bool AddAddress(Address model)
        {

        }

        public IQueryable<Address> GetAddresses()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Address> GetAddressForID()
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
