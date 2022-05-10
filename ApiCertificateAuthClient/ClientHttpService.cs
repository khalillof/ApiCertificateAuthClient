using System.Text.Json;
using System.Text.Json.Nodes;

namespace ApiCertificateAuthClient
{
    public class ClientHttpService : IClientHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientHttpService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public async Task<JsonDocument> GetAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("namedClient");
            var _httpResponse = await httpClient.GetAsync("https://localhost:7282/WeatherForecast");

            if (_httpResponse.IsSuccessStatusCode)
            {

                return JsonDocument.Parse(await _httpResponse.Content.ReadAsStringAsync());
            }

            //string dataa = @" [ {""name"": ""John Doe"", ""occupation"": ""gardener""}]";

            var data = new JsonObject
            {
                ["status_code"] =  _httpResponse.StatusCode.ToString()
            };
            var options = new JsonSerializerOptions { WriteIndented = true };
            return   JsonDocument.Parse(data.ToJsonString(options));     
        }
    }
}
