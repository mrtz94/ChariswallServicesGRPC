using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class EndDurationRepository : ChariswallRepository<EndDuration>, IEndDurationRepository
    {
        public EndDurationRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
