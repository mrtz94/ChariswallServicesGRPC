using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface INimaTransferTypeRepository : IQueryRepository<NimaTransferType>, ICommandRepository<NimaTransferType>
    {
        int GetTransferType(string tt);
    }
}
