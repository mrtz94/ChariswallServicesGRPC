using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IXerateRepository : IQueryRepository<Xerate>, ICommandRepository<Xerate>
    {
    }
}
