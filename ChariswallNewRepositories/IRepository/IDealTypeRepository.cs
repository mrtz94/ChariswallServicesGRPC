using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IDealTypeRepository : IQueryRepository<DealType>, ICommandRepository<DealType>
    {
        int GetDealType(string dealtypeName);
    }
}
