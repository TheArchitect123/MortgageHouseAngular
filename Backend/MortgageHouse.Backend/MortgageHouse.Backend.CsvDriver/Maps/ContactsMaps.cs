using CsvHelper.Configuration;
using MortgageHouse.Backend.Domain.Entities;

namespace MortgageHouse.Backend.CsvDriver.Maps
{
    public class ContactsMaps : ClassMap<Contact>
    {
        public ContactsMaps()
        {
            Map(m => m.FirstName).Name("FirstName");
            Map(m => m.LastName).Name("LastName");
            Map(m => m.MiddleName).Name("MiddleName");
            Map(m => m.PhoneNumber).Name("PhoneNumber");
            Map(m => m.DateOfBirth).Name("DateOfBirth");
        }
    }
}
