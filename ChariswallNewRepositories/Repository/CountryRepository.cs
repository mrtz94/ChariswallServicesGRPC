using ChariswallNewDomain.Context;
using ChariswallNewDomain.Models;
using ChariswallNewRepositories.IRepository;

namespace ChariswallNewRepositories.Repository
{
    public class CountryRepository : ChariswallRepository<Country>, ICountryRepository
    {
        public CountryRepository(ChariswallDemoDbContext context) : base(context)
        {
        }

        public int GetCountry(string country)
        {
            var countryId = _context.Countries.FirstOrDefault(f => f.Ftitle == country)?.Id;
            if (countryId == null)
            {
                var countryRecord = new Country { Ftitle = country, Enable = true, Etitle = "", SanaId = 0 };
                _context.Countries.Add(countryRecord);
                _context.SaveChanges();
                countryId = countryRecord.Id;
            }
            return countryId ?? 0;
        }
    }
}
