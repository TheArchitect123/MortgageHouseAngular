using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortgageHouse.Backend.Domain.Entities
{
    public interface IContactsRepository : IUnitOfWork
    {
        bool AddContact(Contact model);

        Contact GetContactForName(string name);
        IQueryable<Contact> GetContacts();
    }
}
