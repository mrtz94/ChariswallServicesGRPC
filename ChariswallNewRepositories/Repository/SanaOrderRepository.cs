using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class SanaOrderRepository : ChariswallRepository<SanaOrder>, ISanaOrderRepository
    {
        public SanaOrderRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
