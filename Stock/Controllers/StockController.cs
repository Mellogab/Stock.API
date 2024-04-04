using Microsoft.AspNetCore.Mvc;
using Stock.Core;
using Stock.Core.Boundaries;
using Stock.Core.UseCases.Adapters;
using Stock.Presenters;
using System.Net;
using System.Reflection;

namespace StockAPI.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly ILogger<StockController> _logger;
        public StockController(ILogger<StockController> logger) => _logger = logger;

        [HttpPost]
        [Route("process-stocks-internet-async")]
        public async Task<ActionResult> GetFundsAsync(
            [FromServices] IExtractStocksFromInternet useCase,
            [FromServices] DefaultPresenter<UseCaseResponseMessage> presenter,
            [FromBody] ExtractStockInput input
        )
        {
            try
            {
                await useCase.Handle(input, presenter);
                return presenter.GetJsonResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error On {MethodBase.GetCurrentMethod().Name}. Ex {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("get-all-stocks-async")]
        public async Task<ActionResult> GetAllStocksAsync(
            [FromServices] IGetAllStocks useCase,
            [FromServices] DefaultPresenter<UseCaseResponseMessage> presenter,
            [FromQuery] GetAllStocksInput input
        )
        {
            try
            {
                await useCase.Handle(input, presenter);
                return presenter.GetJsonResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error On {MethodBase.GetCurrentMethod().Name}. Ex {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("get-cheapest-stocks-async")]
        public async Task<ActionResult> GetCheapestStocksAsync(
            [FromServices] IGetCheapestStocks useCase,
            [FromServices] DefaultPresenter<UseCaseResponseMessage> presenter,
            [FromQuery] GetCheapestStocksInput input
        )
        {
            try
            {
                await useCase.Handle(input, presenter);
                return presenter.GetJsonResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error On {MethodBase.GetCurrentMethod().Name}. Ex {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
