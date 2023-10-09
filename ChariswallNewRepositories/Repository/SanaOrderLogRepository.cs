using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class SanaOrderLogRepository : ChariswallRepository<SanaOrderLog>, ISanaOrderLogRepository
    {
        public SanaOrderLogRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
