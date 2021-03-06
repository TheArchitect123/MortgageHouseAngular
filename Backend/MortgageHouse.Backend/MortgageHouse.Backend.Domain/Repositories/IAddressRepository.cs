﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MortgageHouse.Backend.Domain.Entities
{
    public interface IAddressRepository : IUnitOfWork
    {
        bool AddAddress(Address model);

        Address GetAddressForID(string streetName);
        IEnumerable<Address> GetAddresses();
    }


}
