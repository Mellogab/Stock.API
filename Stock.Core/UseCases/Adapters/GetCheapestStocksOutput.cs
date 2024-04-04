using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.UseCases.Adapters
{
    public class GetCheapestStocksOutput : UseCaseResponseMessage
    {
        public List<Entities.CheapestStock> Stocks { get; set; }

        public GetCheapestStocksOutput(
            bool success,
            string message = null,
            string error = null
        ) : base(success, message, error)
        {
        }

        public GetCheapestStocksOutput(
            List<Entities.CheapestStock> stock,
            bool success
        ) : base(success, null, null)
        {
            this.Stocks = stock;
        }
    }
}
