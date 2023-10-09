using System.Linq.Expressions;

namespace ChariswallNewRepositories.IRepository
{
    public interface IQueryRepository<T> where T : class
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }
}
