using BinanceReactDemo.API.Models.BinanceHub;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BinanceReactDemo.API.Hubs
{
    public class BinanceHub : Hub
    {
        private readonly HttpClient _client;
        private string? _previousValue;
        private readonly string _binanceApiEndpoint;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">HttpClient</param>
        /// <param name="apiSettingsOptions">Api Settings</param>
        public BinanceHub(HttpClient client, IOptions<ApiSettings> apiSettingsOptions)
        {
            _client = client;
            _previousValue = null;
            _binanceApiEndpoint = apiSettingsOptions.Value.BinanceApiEndpoint;
        }

        /// <summary>
        /// Get Api Value When First Application Start.Used Synchronization.
        /// </summary>
        /// <returns>Api Value.</returns>
        public async Task<string?> GetInitialData()
        {
            while (true)
            {
                var apiValue = await FetchApiValueAsync();

                if (apiValue != _previousValue)
                {
                    await UpdateChartAsync(apiValue);
                    _previousValue = apiValue;
                }

                if (apiValue.Equals("stop"))
                {
                    break;
                }

                await Task.Delay(TimeSpan.FromSeconds(45));
            }

            return null;
        }

        private async Task<string> FetchApiValueAsync()
        {
            HttpResponseMessage response = await _client.GetAsync(_binanceApiEndpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private async Task UpdateChartAsync(string apiValue)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };

            var takenData = BinanceItems(apiValue, serializeOptions);

            var serializeData = JsonSerializer.Serialize(takenData, serializeOptions);

            await Clients.All.SendAsync("UpdateChart", serializeData);
        }

        private static List<BinanceItem> BinanceItems(string apiValue, JsonSerializerOptions jsonSerializerOptions)
        {
            List<BinanceItem>? dataItems = JsonSerializer.Deserialize<List<BinanceItem>>(apiValue, jsonSerializerOptions);

            return dataItems!.Take(10).ToList();
        }
    }
}
