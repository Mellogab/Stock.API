using Newtonsoft.Json;
using Stock.Core;
using Stock.Core.Services;
using System.Text;

namespace Stock.Infrastructure.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        public async Task<HttpRequestUseCaseOutput> MakeRequest(HttpRequestUseCaseInput input)
        {
            try
            {
                if (input.Headers is null)
                    input.Headers = new Dictionary<string, string>();

                using (HttpClient client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(input.HttpMethod, input.Uri);

                    foreach (var (key, value) in input.Headers)
                        request.Headers.Add(key, value);

                    if ((HttpMethod.Post == input.HttpMethod || HttpMethod.Put == input.HttpMethod) && input.Content != null)
                    {
                        var stringContent = new StringContent(input.Content, Encoding.UTF8, "application/json");
                        {
                            request.Content = stringContent;
                        }
                    }

                    HttpResponseMessage response = client
                        .SendAsync(request)
                        .GetAwaiter()
                        .GetResult();

                    if (!response.IsSuccessStatusCode)
                    {
                        return new HttpRequestUseCaseOutput
                        {
                            Successfully = false,
                            Error = JsonConvert.DeserializeObject<object>(response.Content.ReadAsStringAsync().Result)
                        };
                    }

                    response.EnsureSuccessStatusCode();
                    HttpContent content = response.Content;
                    var contentResponse = await content.ReadAsStringAsync();

                    return new HttpRequestUseCaseOutput
                    {
                        output = contentResponse
                    };
                }
            }
            catch (Exception ex)
            {
                return new HttpRequestUseCaseOutput
                {
                    Successfully = false,
                    output = ex.ToString()
                };
            }
        }
    }
}
