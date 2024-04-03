using AutoMapper;
using HtmlAgilityPack;
using Stock.Core.Boundaries;
using Stock.Core.Services;
using Stock.Core.UseCases.Adapters;
using Stock.Core.Repository;
using Stock.Presenters;

namespace Stock.Core.UseCases
{
    public class ExtractStocksFromInternet : IExtractStocksFromInternet
    {
        private IHttpRequestService IHttpRequestService;
        private IMapper IMapper;
        private IStockRepository _StockRepository;
        private ICalculateCheapestStocks _ICalculateCheapestStocks;
        private DefaultPresenter<CalculateCheapestStocksOutput> _OutputPort;

        public ExtractStocksFromInternet(
            IHttpRequestService iHttpRequestService,
            IMapper iMapper,
            IStockRepository _stockRepository,
            ICalculateCheapestStocks _iCalculateCheapestStocks
        )
        {
            this.IHttpRequestService = iHttpRequestService;
            this.IMapper = iMapper;
            this._StockRepository = _stockRepository;
            this._ICalculateCheapestStocks = _iCalculateCheapestStocks;
        }

        public async Task<bool> Handle(ExtractStockInput message, IOutputPort<ExtractStockOutput> outputPort)
        {
            var stocks = new List<Entities.Stock>();
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123.0.0.0 Safari/537.36");
            
            var htmlContent = await this.IHttpRequestService.MakeRequest(
                new HttpRequestUseCaseInput()
                {
                    Uri = "https://www.fundamentus.com.br/resultado.php",
                    HttpMethod = HttpMethod.Get,
                    Headers = dictionary
                }
            );

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent.output);
            HtmlNode tableNode = doc.DocumentNode.SelectSingleNode("//table[@id='resultado']");

            if(tableNode is null)
            {
                outputPort.Handle(new ExtractStockOutput(false, "Houve um problema no processamento das informações. Tabela não encontrado no html"));
                return true;
            }

            foreach (HtmlNode row in tableNode.SelectNodes(".//tbody//tr"))
            {
                var stock = IMapper.Map<Entities.Adapters.StockFromInternet>(row);
                    
                if (stock != null)
                    stocks.Add(stock.BuildStock());
            }

            await _StockRepository.AddMany(stocks);

            var cheapestStocks = new DefaultPresenter<UseCaseResponseMessage>();
            await this._ICalculateCheapestStocks.Handle(new CalculateCheapestStocksInput(stocks), cheapestStocks);
            
            outputPort.Handle(new ExtractStockOutput(stocks, true));
            return true;
        }
    }
}