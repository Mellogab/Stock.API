using Stock.Core.UseCases.Adapters;

namespace Stock.Core.Boundaries
{
    public interface IExtractStocksFromInternet : IUseCaseRequestHandler<ExtractStockInput, ExtractStockOutput>
    {
    }
}
