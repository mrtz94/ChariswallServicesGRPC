using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ISanaOrderReasonRepository : IQueryRepository<SanaOrderReason>, ICommandRepository<SanaOrderReason>
    {
    }
}
