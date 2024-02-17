using BinanceReactDemo.API.Models.BinanceHub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BinanceReactDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly string _binanceApiEndpoint;
        public ModalController(HttpClient client, IOptions<ApiSettings> apiSettingsOptions)
        {
            _client = client;
            _binanceApiEndpoint = apiSettingsOptions.Value.BinanceApiEndpoint;
        }

        [HttpGet("fillModal")]
        public async Task<IActionResult> FillModal()
        {
            var result = await GetFillModal();

            return Ok(result);
        }

        private async Task<List<BinanceItem>> GetFillModal()
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
