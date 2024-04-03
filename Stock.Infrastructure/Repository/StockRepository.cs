using MongoDB.Driver;
using Stock.Core.Entities;
using Stock.Core.Repository;
using Stock.Infrastructure.Respository;

namespace Stock.Infrastructure.Repository
{
    public class StockRepository : Repository<Core.Entities.Stock>, IStockRepository
    {
        string ENTITY_NAME = "Stock";
        public StockRepository(MongoDbContext mongoContext) : base(mongoContext)
        {
            //collectionName = this.ENTITY_NAME;
        }
    }
}
