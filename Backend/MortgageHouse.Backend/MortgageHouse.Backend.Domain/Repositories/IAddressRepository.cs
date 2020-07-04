using System.Collections;
using System.Linq;

namespace MortgageHouse.Backend.Domain.Entities
{
    public interface IAddressRepository : IUnitOfWork
    {
        bool AddAddress(Address model);

        IQueryable<Address> GetAddressForID();
        IQueryable<Address> GetAddresses();
    }
}
