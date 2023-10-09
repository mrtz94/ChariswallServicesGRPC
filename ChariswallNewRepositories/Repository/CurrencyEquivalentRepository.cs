using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;
using System.Text.RegularExpressions;

namespace ChariswallNewRepositories.Repository
{
    public class CurrencyEquivalentRepository : ChariswallRepository<CurrencyEquivalent>, ICurrencyEquivalentRepository
    {
        public CurrencyEquivalentRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

    }
}
