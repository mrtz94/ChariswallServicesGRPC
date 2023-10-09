using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IRialPaymentMethodRepository : IQueryRepository<RialPaymentMethod>, ICommandRepository<RialPaymentMethod>
    {
        int GetMethod(string rpm);
    }
}
