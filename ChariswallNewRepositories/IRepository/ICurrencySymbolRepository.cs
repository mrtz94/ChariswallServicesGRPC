using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ICurrencySymbolRepository : IQueryRepository<CurrencySymbol>, ICommandRepository<CurrencySymbol>
    {
    }
}
