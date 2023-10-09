using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class CreditRepository : ChariswallRepository<Credit>, ICreditRepository
    {
        public CreditRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
