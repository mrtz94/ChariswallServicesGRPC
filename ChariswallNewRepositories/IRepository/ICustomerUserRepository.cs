using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ICustomerUserRepository : IQueryRepository<CustomerUser>, ICommandRepository<CustomerUser>
    {
        int GetUser(string userName, string phone, int customer, int? bank);
    }
}
