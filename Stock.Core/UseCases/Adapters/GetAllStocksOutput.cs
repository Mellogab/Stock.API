using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.UseCases.Adapters
{
    public class GetAllStocksOutput : UseCaseResponseMessage
    {
        public List<Entities.Stock> Stocks { get; set; }

        public GetAllStocksOutput(
            bool success,
            string message = null,
            string error = null
        ) : base(success, message, error)
        {
        }

        public GetAllStocksOutput(
            List<Entities.Stock> stock,
            bool success
        ) : base(success, null, null)
        {
            this.Stocks = stock;
        }
    }
}
