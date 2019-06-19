using System;
using System.Threading.Tasks;
using RestSharp;

namespace HaveIBeenPwned.Client
{
    public partial class HaveIBeenPwnedClient : IHaveIBeenPwnedClient
    {
        private const int TIMEOUT_MS = 30000;

        private readonly RestClient _client = new RestClient
        {
            BaseUrl = new Uri("https://haveibeenpwned.com/api/v2"),
            Timeout = TIMEOUT_MS
        };

        private async Task<T> ExecuteTaskAsync<T>(IRestRequest request) where T : new()
        {
            IRestResponse<T> response = await _client.ExecuteTaskAsync<T>(request);
            return response.Data;
        }
    }
}