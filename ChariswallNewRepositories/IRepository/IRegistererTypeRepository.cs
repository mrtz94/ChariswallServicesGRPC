using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IRegistererTypeRepository : IQueryRepository<RegistererType>, ICommandRepository<RegistererType>
    {
        int GetRegistererType(string rttitle);
    }
}
