using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface IExchangeCustomerRepository : IQueryRepository<ExchangeCustomer>, ICommandRepository<ExchangeCustomer>
    {
        int GetCustomer(string Company, string NationalID, int ctype, DateTime? CustomerRegisterDate, string CustomerRegisterNumber, string Firstname, string Lastname, string? IDInquiryState = null);
    }
}
