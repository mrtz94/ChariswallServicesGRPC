using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ICreditRepository : IQueryRepository<Credit>, ICommandRepository<Credit>
    {
    }
}
