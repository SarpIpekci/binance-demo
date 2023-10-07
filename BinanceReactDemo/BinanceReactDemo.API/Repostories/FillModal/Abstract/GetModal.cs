using BinanceReactDemo.API.DataTransferObject;
using BinanceReactDemo.API.Models.BinanceHub;
using BinanceReactDemo.API.Repostories.FillModal.Interface;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BinanceReactDemo.API.Repostories.FillModal.Abstract
{
    public class GetModal : IGetModal
    {
        private readonly HttpClient _client;
        private readonly string _binanceApiEndpoint;

        public GetModal(HttpClient client, IOptions<ApiSettings> apiSettingsOptions)
        {
            _client = client;
            _binanceApiEndpoint = apiSettingsOptions.Value.BinanceApiEndpoint;
        }
        public async Task<List<BinanceItem>> GetFillModal()
        {
            var apiValue = await FetchApiValueAsync();

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };

            return BinanceItems(apiValue, serializeOptions);
        }

        private async Task<string> FetchApiValueAsync()
        {
            HttpResponseMessage response = await _client.GetAsync(_binanceApiEndpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private static List<BinanceItem> BinanceItems(string apiValue, JsonSerializerOptions jsonSerializerOptions)
        {
            List<BinanceItem>? dataItems = JsonSerializer.Deserialize<List<BinanceItem>>(apiValue, jsonSerializerOptions);

            return dataItems!.Take(10).ToList();
        }
    }
}
