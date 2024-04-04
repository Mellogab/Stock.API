using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Stock.Core.IUseCaseRequest;

namespace Stock.Core.UseCases.Adapters
{
    public class GetCheapestStocksInput : IUseCaseRequest<GetCheapestStocksOutput>
    {
    }
}
