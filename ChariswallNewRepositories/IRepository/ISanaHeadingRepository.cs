using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ISanaHeadingRepository : IQueryRepository<SanaHeading>, ICommandRepository<SanaHeading>
    {
        int GetHeading(string headingName);
    }
}
