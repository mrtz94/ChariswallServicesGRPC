using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ITrustyRepository : IQueryRepository<Trusty>, ICommandRepository<Trusty>
    {
    }
}
