
namespace Stock.Core.Services
{
    public interface IHttpRequestService
    {
        Task<HttpRequestUseCaseOutput> MakeRequest(HttpRequestUseCaseInput input);
    }
}
