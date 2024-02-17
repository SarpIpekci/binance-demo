using BinanceReactDemo.Business.Abstract.CustomerCoinTable;
using BinanceReactDemo.Validation.HtmlEncoded;
using BinanceReactDemo.Validation.XSSControl;
using Microsoft.AspNetCore.Mvc;

namespace BinanceReactDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTableController : ControllerBase
    {
        private readonly ICustomerCoinTableService _customerCoinTableService;

        public CustomerTableController(ICustomerCoinTableService customerCoinTableService)
        {
            _customerCoinTableService = customerCoinTableService;
        }

        [HttpGet("getBuyCoin")]
        [DynamicXssControl]
        [DynamicHtmlEncode]
        public async Task<IActionResult> GetBuyCoin(int customerId)
        {
            var result = await _customerCoinTableService.GetBuyCoinsById(customerId);

            return Ok(result);
        }

        [HttpGet("getSellCoin")]
        public async Task<IActionResult> GetSellCoin(int customerId)
        {
            var result = await _customerCoinTableService.GetSellCoinsById(customerId);

            return Ok(result);
        }

        [HttpGet("getAllCoins")]
        public async Task<IActionResult> GetAllCoins(int customerId)
        {
            var result = await _customerCoinTableService.GetAllCoinsById(customerId);

            return Ok(result);
        }
    }
}
