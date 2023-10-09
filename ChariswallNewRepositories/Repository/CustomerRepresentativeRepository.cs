using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class CustomerRepresentativeRepository : ChariswallRepository<CustomerRepresentative>, ICustomerRepresentativeRepository
    {
        public CustomerRepresentativeRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetContact(string firstName, string lastName, DateTime? bdate, string Identification, string IDInquiryState, string NCode, string phone, int customer, int ctype)
        {
            var contactId = _context.CustomerRepresentatives.FirstOrDefault(f => f.Firstname.Trim() == firstName.Trim() && f.Lastname.Trim() == lastName.Trim())?.Id;
            if (contactId == null)
            {
                var contact = new CustomerRepresentative
                {
                    Customer = customer,
                    Firstname = firstName.Trim(),
                    Lastname = lastName.Trim(),
                    Birthdate = bdate,
                    NationalCode = NCode,
                    IdentificationNumber = Identification,
                    IdinquiryState = IDInquiryState,
                    Phone = phone
                };
                _context.CustomerRepresentatives.Add(contact);
                _context.SaveChanges();
                contactId = contact.Id;
            }
            return contactId ?? 0;
        }
    }
}
