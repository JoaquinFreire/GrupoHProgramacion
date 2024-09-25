using System.Linq.Expressions;

namespace Core.Application.Repositories
{
    public interface IMongoDbRepository<TEntity>
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        long Count(Expression<Func<TEntity, bool>> filter);
        Task<long> CountAsync(Expression<Func<TEntity, bool>> filter);
        IList<TEntity> FindAll();
        Task<List<TEntity>> FindAllAsync();
        TEntity FindOne(object id);
        Task<TEntity> FindOneAsync(object id);
        void Remove(object id);
        void Update(object id, TEntity entity);
    }
}
