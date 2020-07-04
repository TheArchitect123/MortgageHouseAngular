namespace MortgageHouse.Backend.Domain.Entities
{
    public interface IUnitOfWork
    {
        bool SaveChanges();
    }
}
