using System.Collections.Generic;

namespace MortgageHouse.Backend.Domain.Entities
{
    public interface IContactsAddressRepository : IUnitOfWork
    {
        bool AddContactAddress(ContactAddress model);
        IEnumerable<ContactAddress> GetContactAddresses();
    }


}
