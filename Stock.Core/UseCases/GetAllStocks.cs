using AutoMapper;
using Stock.Core.Boundaries;
using Stock.Core.Repository;
using Stock.Core.Services;
using Stock.Core.UseCases.Adapters;
using Stock.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.UseCases
{
    public class GetAllStocks : IGetAllStocks
    {

        private IStockRepository _StockRepository;
        
        public GetAllStocks(
            IStockRepository _stockRepository
        )
        {
            this._StockRepository = _stockRepository;
        }

        public async Task<bool> Handle(GetAllStocksInput message, IOutputPort<GetAllStocksOutput> outputPort)
        {
            var allStocks = await this._StockRepository.GetAll();
            
            outputPort.Handle(new GetAllStocksOutput(allStocks.ToList(), true));
            return true;
        }
    }
}
