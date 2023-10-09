using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ICustomerTradeTypeRepository : IQueryRepository<CustomerTradeType>, ICommandRepository<CustomerTradeType>
    {
    }
}
