using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ICurrencyEquivalentRepository : IQueryRepository<CurrencyEquivalent>, ICommandRepository<CurrencyEquivalent>
    {
    }
}
