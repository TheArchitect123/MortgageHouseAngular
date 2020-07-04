using CsvHelper.Configuration;
using MortgageHouse.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageHouse.Backend.CsvDriver.Maps
{
    public class AddressMaps : ClassMap<Address>
    {
        public AddressMaps()
        {
            Map(m => m.StreetName).Name("StreetName");
            Map(m => m.StreetNumber).Name("StreetNumber");
            Map(m => m.Postcode).Name("Postcode");
            Map(m => m.Suburb).Name("Suburb");
            Map(m => m.StreetOption).Name("StreetOption");
        }
    }
}
