using Stock.Core.UseCases.Adapters;

namespace Stock.Core.Boundaries
{
    public interface IGetAllStocks : IUseCaseRequestHandler<GetAllStocksInput, GetAllStocksOutput>
    {
    }
}
