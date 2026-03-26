namespace Trainova.Domain.Common
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T entity);
        T Update(T entity);
        Task Delete(T entity);
        Task<int> Save();
    }
}
