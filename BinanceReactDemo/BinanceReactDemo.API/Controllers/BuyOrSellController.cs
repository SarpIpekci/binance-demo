using BinanceReactDemo.Business.Abstract;
using BinanceReactDemo.Business.Abstract.SellCoin;
using BinanceReactDemo.Common.UserInformatiomErrorMessages;
using BinanceReactDemo.Common.UserInformationMessages;
using BinanceReactDemo.DataTransferObject.Models;
using BinanceReactDemo.Validation.BuyCoin;
using BinanceReactDemo.Validation.DynamicValidationAndEncoded;
using BinanceReactDemo.Validation.HtmlEncoded;
using BinanceReactDemo.Validation.SellCoin;
using BinanceReactDemo.Validation.XSSControl;
using Microsoft.AspNetCore.Mvc;

namespace BinanceReactDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyOrSellController : ControllerBase
    {
        private readonly IBuyCoinService _buyCoinService;
        private readonly ISellCoinService _sellCoinService;

        public BuyOrSellController(IBuyCoinService buyCoinService, ISellCoinService sellCoinService)
        {
            _buyCoinService = buyCoinService;
            _sellCoinService = sellCoinService;
        }

        [HttpPost("buy")]
        [DynamicValidation(typeof(BuyCoinValidation))]
        [DynamicXssControl]
        [DynamicHtmlEncode]
        public async Task<IActionResult> BuyCoinForm([FromBody] BuyCoinDto request)
        {
            try
            {
                var isSuccess = await _buyCoinService.BuyCoins(request);

                if (isSuccess)
                {
                    return Ok(new { message = UserInformationMessages.BuyCoin });
                }
                else
                {
                    return BadRequest(new { message = UserInformationErrorMessages.BuyCoinError });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpPost("sell")]
        [DynamicValidation(typeof(SellCoinValidation))]
        [DynamicXssControl]
        [DynamicHtmlEncode]
        public async Task<IActionResult> SellCoinForm([FromBody] SellCoinDto request)
        {
            try
            {
                var isSuccess = await _sellCoinService.SellCoins(request);

                if (isSuccess)
                {
                    return Ok(new { message = UserInformationMessages.SellCoin });
                }
                else
                {
                    return BadRequest(new { message = UserInformationErrorMessages.SellCoinError });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
