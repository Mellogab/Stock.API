using Stock.Core.UseCases;
using Stock.Core.UseCases.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.Boundaries
{
    public interface IGetCheapestStocks : IUseCaseRequestHandler<GetCheapestStocksInput, GetCheapestStocksOutput>
    {
    }
}
