namespace Data.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public T? GetSingle(Func<T, bool> condition);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void Save();
    }
}
