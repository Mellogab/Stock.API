using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.UseCases.Adapters
{
    public class CalculateCheapestStocksOutput : UseCaseResponseMessage
    {
        public List<Entities.CheapestStock> Stocks { get; set; }

        public CalculateCheapestStocksOutput() { }

        public CalculateCheapestStocksOutput(
            bool success,
            string message = null,
            string error = null
        ) : base(success, message, error)
        {
        }

        public CalculateCheapestStocksOutput(
            List<Entities.CheapestStock> stock,
            bool success
        ) : base(success, null, null)
        {
            this.Stocks = stock;
        }
    }
}
