using static Stock.Core.IUseCaseRequest;

namespace Stock.Core.UseCases.Adapters
{
    public class CalculateCheapestStocksInput : IUseCaseRequest<CalculateCheapestStocksOutput>
    {
        public CalculateCheapestStocksInput(List<Entities.Stock> Stocks) 
        { 
            this.Stocks = Stocks;
        }

        public List<Entities.Stock> Stocks { get; set; }
    }
}
