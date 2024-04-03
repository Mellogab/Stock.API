namespace Stock.Core.UseCases.Adapters
{
    public class ExtractStockOutput : UseCaseResponseMessage
    {
        public List<Entities.Stock> Stocks { get; set; }

        public ExtractStockOutput(
            bool success,
            string message = null,
            string error = null
        ) : base(success, message, error)
        {
        }

        public ExtractStockOutput(
            List<Entities.Stock> stock,
            bool success
        ) : base(success, null, null)
        {
            this.Stocks = stock;
        }
    }
}