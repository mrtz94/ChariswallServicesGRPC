using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class CurrencySymbolRepository : ChariswallRepository<CurrencySymbol>, ICurrencySymbolRepository
    {
        public CurrencySymbolRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
    }
}
