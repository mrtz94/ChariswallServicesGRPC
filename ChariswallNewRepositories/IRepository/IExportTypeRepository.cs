using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IExportTypeRepository : IQueryRepository<ExportType>, ICommandRepository<ExportType>
    {
        int GetExportType(string et);
    }
}
