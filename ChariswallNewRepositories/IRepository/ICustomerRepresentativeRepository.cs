using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ICustomerRepresentativeRepository : IQueryRepository<CustomerRepresentative>, ICommandRepository<CustomerRepresentative>
    {
        int GetContact(string firstName, string lastName, DateTime? bdate, string Identification, string IDInquiryState, string NCode, string phone, int customer, int ctype);
    }
}
