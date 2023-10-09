namespace ChariswallNewRepositories.IRepository
{
    public interface ICommandRepository<T> where T : class
    {
        void Add(T entity);
        void Edit(T entity);
        void AddRange(IEnumerable<T> entities);
        void EditRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void RemoveAll();
    }
}
