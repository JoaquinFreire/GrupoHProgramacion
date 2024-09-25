using Core.Application.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Core.Infraestructure.Repositories.MongoDb
{
    public class BaseRepository<TEntity> : IMongoDbRepository<TEntity> where TEntity : class
    {
        public DbContext Context { get; private set; }

        public IMongoCollection<TEntity> Collection { get; private set; }

        public BaseRepository(DbContext context)
        {
            Context = context;
            Collection = Context.GetCollection<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Collection.InsertOne(entity);
        }

        public Task AddAsync(TEntity entity)
        {
            return Collection.InsertOneAsync(entity);
        }

        public long Count(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.CountDocuments(filter);
        }

        public Task<long> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Collection.CountDocumentsAsync(filter);
        }

        public IList<TEntity> FindAll()
        {
            FilterDefinition<TEntity> filter = new BsonDocumentFilterDefinition<TEntity>(new BsonDocument());
            return Collection.Find(filter).ToList();
        }

        public Task<List<TEntity>> FindAllAsync()
        {
            FilterDefinition<TEntity> filter = new BsonDocumentFilterDefinition<TEntity>(new BsonDocument());
            return Collection.Find(filter).ToListAsync();
        }

        public TEntity FindOne(object id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", id);
            return Collection.Find(filter).SingleOrDefault();
        }

        public Task<TEntity> FindOneAsync(object id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", id);
            return Collection.Find(filter).SingleOrDefaultAsync();
        }

        public void Remove(object id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", id);
            Collection.DeleteOne(filter);
        }

        public void Update(object id, TEntity entity)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", id);
            Collection.ReplaceOne(filter, entity);
        }
    }
}
