using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class IndustryRepository : ChariswallRepository<Industry>, IIndustryRepository
    {
        public IndustryRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
