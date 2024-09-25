using Core.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Infraestructure.Repositories.Sql
{
    public class BaseRepository<TEntity> : ISqlRepository<TEntity> where TEntity : class
    {
        public DbContext Context { get; private set; }
        public DbSet<TEntity> Repository { get; private set; }

        public BaseRepository(DbContext context)
        {
            Context = context;
            Repository = Context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Repository.Add(entity);
            Context.SaveChanges();
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await Repository.AddAsync(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<string> AddOneAsync(TEntity entity)
        {
            await Repository.AddAsync(entity);
            await Context.SaveChangesAsync();

            return Context.Entry(entity).Property("Id").CurrentValue.ToString();
        }

        public long Count(Expression<Func<TEntity, bool>> filter)
        {
            return Repository.Count(filter);
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Repository.CountAsync(filter);
        }

        public IList<TEntity> FindAll()
        {
            //Expresion de coleccion. Similar a Repository.ToList()
            return [.. Repository];
        }

        public Task<List<TEntity>> FindAllAsync()
        {
            return Repository.ToListAsync();
        }

        public TEntity FindOne(params object[] keyValues)
        {
            return Repository.Find(keyValues);
        }

        public ValueTask<TEntity> FindOneAsync(params object[] keyValues)
        {
            return Repository.FindAsync(keyValues);
        }

        public void Remove(TEntity entity)
        {
            Repository.Remove(entity);
            Context.SaveChanges();
        }

        public void Remove(params object[] keyValues)
        {
            TEntity entity = FindOne(keyValues);

            if (entity != null)
            {
                Repository.Remove(entity);
                Context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            Repository.Update(entity);
            Context.SaveChanges();
        }
    }
}
