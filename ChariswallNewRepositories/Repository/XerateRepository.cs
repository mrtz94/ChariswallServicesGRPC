using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class XerateRepository : ChariswallRepository<Xerate>, IXerateRepository
    {
        public XerateRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
