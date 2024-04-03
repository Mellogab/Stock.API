using AutoMapper;
using Stock.Core.Boundaries;
using Stock.Core.Entities;
using Stock.Core.Repository;
using Stock.Core.Services;
using Stock.Core.UseCases.Adapters;

namespace Stock.Core.UseCases
{
    public class CalculateCheapestStocks : ICalculateCheapestStocks
    {
        private ICheapestStockRepository _CheapestStockRepository;
        
        public CalculateCheapestStocks(
            ICheapestStockRepository _cheapestStockRepository
        )
        {
            this._CheapestStockRepository = _cheapestStockRepository;
        }

        public async Task<bool> Handle(CalculateCheapestStocksInput message, IOutputPort<CalculateCheapestStocksOutput> outputPort)
        {
            List<CheapestStock> cheapestStocks = new List<CheapestStock>();
            
            cheapestStocks = message.Stocks
                .Where(arg => arg.VolumeTraded > 200000)
                .Where(arg => arg.PEBIT > 0)
                .OrderByDescending(arg => arg.EVEBIT)
                .Take(50)
                .Select(arg => new CheapestStock{
                    CanBeCheapest = arg.CanBeCheapest,
                    DividendYield = arg.DividendYield,
                    EVEBIT = arg.EVEBIT,
                    EVEBITDA = arg.EVEBITDA,
                    Id = arg.Id,
                    NetEquity = arg.NetEquity,
                    Paper = arg.Paper,
                    PEBIT = arg.PEBIT,
                    Quotation = arg.Quotation,
                    ROE = arg.ROE,
                    ROIC = arg.ROIC,
                    VolumeTraded = arg.VolumeTraded
                })
                .ToList();

            await this._CheapestStockRepository.AddMany(cheapestStocks);

            outputPort.Handle(new CalculateCheapestStocksOutput(cheapestStocks, true));
            return true;
        }
    }
}
