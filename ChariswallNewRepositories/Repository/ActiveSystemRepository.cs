using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class ActiveSystemRepository : ChariswallRepository<ActiveSystem>, IActiveSystemRepository
    {
        public ActiveSystemRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
