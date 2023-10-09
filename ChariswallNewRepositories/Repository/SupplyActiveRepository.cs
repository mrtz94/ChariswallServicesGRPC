using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class SupplyActiveRepository : ChariswallRepository<SupplyActive>, ISupplyActiveRepository
    {
        public SupplyActiveRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
