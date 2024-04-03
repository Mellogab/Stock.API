using Stock.Core.Repository;
using Stock.Infrastructure.Respository;

namespace Stock.Infrastructure.Repository
{
    public class CheapestStockRepository : Repository<Core.Entities.CheapestStock>, ICheapestStockRepository
    {
        public CheapestStockRepository(MongoDbContext mongoContext) : base(mongoContext)
        {
        }
    }
}
