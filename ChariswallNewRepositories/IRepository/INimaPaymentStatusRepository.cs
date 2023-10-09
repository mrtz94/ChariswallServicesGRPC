using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaPaymentStatusRepository : IQueryRepository<NimaPaymentStatus>, ICommandRepository<NimaPaymentStatus>
    {
        int GetPayStatus(string paystatusname);
    }
}
