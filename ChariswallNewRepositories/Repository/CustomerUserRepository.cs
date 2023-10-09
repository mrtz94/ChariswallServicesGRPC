using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class CustomerUserRepository : ChariswallRepository<CustomerUser>, ICustomerUserRepository
    {
        public CustomerUserRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetUser(string userName, string phone, int customer, int? bank)
        {
            var userId = _context.CustomerUsers.FirstOrDefault(f => f.Username.Trim() == userName.Trim() && f.PhoneNumber.Trim() == phone.Trim())?.Id;
            if (userId == null)
            {
                var user = new CustomerUser
                {
                    Customer = customer,
                    PhoneNumber = phone,
                    Username = userName,
                    BankBranch = bank
                };
                _context.CustomerUsers.Add(user);
                _context.SaveChanges();
                userId = user.Id;
            }
            return userId ?? 0;
        }
    }
}
