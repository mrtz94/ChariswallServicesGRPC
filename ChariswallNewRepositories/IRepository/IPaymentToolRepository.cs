using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IPaymentToolRepository : IQueryRepository<PaymentTool>, ICommandRepository<PaymentTool>
    {
        int GetTool(string paymethod);
    }
}
