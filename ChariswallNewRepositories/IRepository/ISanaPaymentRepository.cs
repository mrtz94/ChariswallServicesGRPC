using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ISanaPaymentRepository : IQueryRepository<SanaPayment>, ICommandRepository<SanaPayment>
    {
    }
}
