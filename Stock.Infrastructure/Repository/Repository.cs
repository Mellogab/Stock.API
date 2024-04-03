using MongoDB.Driver;
using Stock.Core.Repository;
using Stock.Infrastructure.Repository;

namespace Stock.Infrastructure.Respository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Core.Entities.Entity
    {
        private readonly IMongoCollection<TEntity> _collection;

        public Repository(MongoDbContext mongoContext)
        {
            var entityType = typeof(TEntity);
            _collection = mongoContext._database.GetCollection<TEntity>(entityType.Name);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<TEntity> GetById(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Add(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task AddMany(List<TEntity> entity)
        {
            await _collection.InsertManyAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", entity.Id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
