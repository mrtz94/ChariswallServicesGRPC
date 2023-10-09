using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaRequestTypeRepository : IQueryRepository<NimaRequestType>, ICommandRepository<NimaRequestType>
    {
        int GetRequestType(string rttitle);
    }
}
