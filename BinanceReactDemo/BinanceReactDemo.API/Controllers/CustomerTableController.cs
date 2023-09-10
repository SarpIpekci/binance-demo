using BinanceReactDemo.API.Repostories.CustomerCoinTable.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BinanceReactDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTableController : ControllerBase
    {
        private readonly ICustomerCoinTables _customerCoinTables;

        public CustomerTableController(ICustomerCoinTables customerCoinTables)
        {
            _customerCoinTables = customerCoinTables;
        }

        [HttpGet("getBuyCoin")]
        public async Task<IActionResult> GetBuyCoin(int CustomerId)
        {
            try
            {
                var result = await _customerCoinTables.GetBuyCoinsById(CustomerId);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet("getSellCoin")]
        public async Task<IActionResult> GetSellCoin(int CustomerId)
        {
            try
            {
                var result = await _customerCoinTables.GetSellCoinsById(CustomerId);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet("getAllCoins")]
        public async Task<IActionResult> GetAllCoins(int CustomerId)
        {
            try
            {
                var result = await _customerCoinTables.GetAllCoinsById(CustomerId);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
