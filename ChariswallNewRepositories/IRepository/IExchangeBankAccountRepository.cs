using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IExchangeBankAccountRepository : IQueryRepository<ExchangeBankAccount>, ICommandRepository<ExchangeBankAccount>
    {
        int GetAccount(string bank,string shaba);
    }
}
