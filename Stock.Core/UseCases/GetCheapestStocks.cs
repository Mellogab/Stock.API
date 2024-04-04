using Stock.Core.Boundaries;
using Stock.Core.Repository;
using Stock.Core.UseCases.Adapters;

namespace Stock.Core.UseCases
{
    public class GetCheapestStocks : IGetCheapestStocks
    {

        private ICheapestStockRepository _CheapestStockRepository;

        public GetCheapestStocks(
            ICheapestStockRepository _cheapeststockRepository
        )
        {
            this._CheapestStockRepository = _cheapeststockRepository;
        }

        public async Task<bool> Handle(GetCheapestStocksInput message, IOutputPort<GetCheapestStocksOutput> outputPort)
        {
            var allStocks = await this._CheapestStockRepository.GetAll();

            outputPort.Handle(new GetCheapestStocksOutput(allStocks.ToList(), true));
            return true;
        }
    }
}
