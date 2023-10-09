using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaRateTypeRepository : IQueryRepository<NimaRateType>, ICommandRepository<NimaRateType>
    {
        int GetRateType(string rttitle);
    }
}
