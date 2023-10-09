using ChariswallNewDomain.Context;
using ChariswallNewRepositories.IRepository;
using System.Linq.Expressions;

namespace ChariswallNewRepositories.Repository
{
    public class ChariswallRepository<T> : IQueryRepository<T>, ICommandRepository<T> where T : class
    {
        protected readonly ChariswallDemoDbContext _context;
        public ChariswallRepository(ChariswallDemoDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Edit(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void EditRange(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void RemoveAll()
        {
            _context.Set<T>().RemoveRange(_context.Set<T>().ToList());
        }
    }
}
