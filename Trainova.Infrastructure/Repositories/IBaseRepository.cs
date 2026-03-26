using Trainova.Domain.Common;
using Trainova.Infrastructure.Database;

namespace Trainova.Infrastructure.Repositories
{
    public class BaseRepository<T>(TrainovaDbContext _trainovaContext) : IBaseRepository<T> where T : BaseEntity
    {
        public async Task<T> Create(T entity)
        {
            await _trainovaContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Save()
        {
            var unit = await _trainovaContext.SaveChangesAsync();
            return unit;
        }

        public T Update(T entity)
        {
            _trainovaContext.Update(entity);
            return entity;
        }
    }
}
