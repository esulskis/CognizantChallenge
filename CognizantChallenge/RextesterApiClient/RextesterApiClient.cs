using CognizantChallenge.Config;
using CognizantChallenge.RextesterApiClient.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CognizantChallenge.RextesterApiClient
{
    public class RextesterApiClient: IRextesterApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _settings;
        public RextesterApiClient(IOptions<AppSettings> settings)
        {
            _httpClient = new HttpClient();
            _settings = settings;
        }

        public async Task<ExecuteCodeResponse> ExecuteCode(ExecuteCodeRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_settings.Value.RextesterApiBaseUrl, data);
            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new Exception($"{nameof(ExecuteCode)} request failed with status code: {response.StatusCode}");

            return JsonConvert.DeserializeObject<ExecuteCodeResponse>(result);
        }
    }
}
