using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class ExpertLevelRepository : ChariswallRepository<ExpertLevel>, IExpertLevelRepository
    {
        public ExpertLevelRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
