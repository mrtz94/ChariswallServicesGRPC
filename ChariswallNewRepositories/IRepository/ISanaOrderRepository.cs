using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ISanaOrderRepository : IQueryRepository<SanaOrder>, ICommandRepository<SanaOrder>
    {
    }
}
