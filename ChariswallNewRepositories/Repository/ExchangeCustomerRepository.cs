using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;
using System.ComponentModel;

namespace ChariswallNewRepositories.Repository
{
    public class ExchangeCustomerRepository : ChariswallRepository<ExchangeCustomer>, IExchangeCustomerRepository
    {
        public ExchangeCustomerRepository(ChariswallDemoDbContext context) : base(context)
        {
        }
        public int GetCustomer(string Company, string NationalID, int ctype, DateTime? CustomerRegisterDate, string CustomerRegisterNumber, string Firstname, string Lastname, string? IDInquiryState = null)
        {
            var ctypeval = _context.CustomerTypes.FirstOrDefault(f => f.Id == ctype)?.Value;
            var customerId = _context.ExchangeCustomers.FirstOrDefault(f => f.NationalCode.Trim() == NationalID.Trim() ||
                (ctypeval == 0 && Company.Trim() == f.Company.Trim()) ||
                (ctypeval == 1 && Firstname.Trim() == f.Firstname.Trim() && Lastname.Trim() == f.Lastname.Trim()))?.Id;
            if (customerId == null)
            {
                var customer = new ExchangeCustomer
                {
                    Company = ctype == 0 ? Company.Trim() : null,
                    CustomerType = ctype,
                    Firstname = ctype == 1 ? Firstname.Trim() : null,
                    Lastname = ctype == 1 ? Lastname.Trim() : null,
                    NationalCode = NationalID.Trim(),
                    RegisterDate = CustomerRegisterDate,
                    RegisterNumber = CustomerRegisterNumber.Trim(),
                    IdinquiryState = IDInquiryState
                };
                _context.ExchangeCustomers.Add(customer);
                _context.SaveChanges();
                customerId = customer.Id;
            }
            return customerId ?? 0;
        }
    }
}
