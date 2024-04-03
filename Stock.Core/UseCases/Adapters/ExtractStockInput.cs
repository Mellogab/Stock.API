using static Stock.Core.IUseCaseRequest;

namespace Stock.Core.UseCases.Adapters
{
    public class ExtractStockInput : IUseCaseRequest<ExtractStockOutput>
    {
        public int Id { get; set; }
    }
}
