using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ICustomerTypeRepository : IQueryRepository<CustomerType>, ICommandRepository<CustomerType>
    {
        int GetCType(string ctype);
    }
}
