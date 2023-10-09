using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ICountryRepository : IQueryRepository<Country>, ICommandRepository<Country>
    {
        int GetCountry(string country);
    }
}
