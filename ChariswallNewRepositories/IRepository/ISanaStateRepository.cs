using ChariswallNewDomain.Models;

namespace ChariswallNewRepositories.IRepository
{
    public interface ISanaStateRepository : IQueryRepository<SanaState>, ICommandRepository<SanaState>
    {
        int GetState(string stateName);
    }
}
