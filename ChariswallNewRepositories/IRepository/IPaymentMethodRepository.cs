using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IPaymentMethodRepository : IQueryRepository<PaymentMethod>, ICommandRepository<PaymentMethod>
    {
        int GetMethod(string paymethod);
    }
}
