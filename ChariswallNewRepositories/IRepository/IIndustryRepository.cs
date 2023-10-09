using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IIndustryRepository : IQueryRepository<Industry>, ICommandRepository<Industry>
    {
    }
}
