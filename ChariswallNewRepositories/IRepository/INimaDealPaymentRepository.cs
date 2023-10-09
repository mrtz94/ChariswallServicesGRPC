using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaDealPaymentRepository : IQueryRepository<NimaDealPayment>, ICommandRepository<NimaDealPayment>
    {
    }
}
