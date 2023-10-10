using BinanceReactDemo.Business.Abstract.CustomerCoinTable;
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
        public async Task<IActionResult> GetBuyCoin(int customerId)
        {
            try
            {
                var result = await _customerCoinTableService.GetBuyCoinsById(customerId);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet("getSellCoin")]
        public async Task<IActionResult> GetSellCoin(int customerId)
        {
            try
            {
                var result = await _customerCoinTableService.GetSellCoinsById(customerId);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet("getAllCoins")]
        public async Task<IActionResult> GetAllCoins(int customerId)
        {
            try
            {
                var result = await _customerCoinTableService.GetAllCoinsById(customerId);

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
