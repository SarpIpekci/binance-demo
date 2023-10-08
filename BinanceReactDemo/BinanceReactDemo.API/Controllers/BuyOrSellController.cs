using BinanceReactDemo.API.Repostories.BuyCoin.Interfaces;
using BinanceReactDemo.API.Repostories.SellCoin.Interfaces;
using BinanceReactDemo.Common.UserInformatiomErrorMessages;
using BinanceReactDemo.Common.UserInformationMessages;
using BinanceReactDemo.DataTransferObject.Models;
using BinanceReactDemo.Validation;
using BinanceReactDemo.Validation.BuyCoin;
using BinanceReactDemo.Validation.SellCoin;
using Microsoft.AspNetCore.Mvc;

namespace BinanceReactDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyOrSellController : ControllerBase
    {
        private readonly IBuyCoinRepository _buyCoinForCustomer;
        private readonly ISellCoinRepository _sellCoinRepository;
        private readonly BuyCoinValidation _buyCoinValidation;
        private readonly SellCoinValidation _sellCoinValidation;

        public BuyOrSellController(IBuyCoinRepository buyCoinForCustomer, BuyCoinValidation buyCoinValidation, ISellCoinRepository sellCoinRepository, SellCoinValidation sellCoinValidation)
        {
            _buyCoinForCustomer = buyCoinForCustomer;
            _sellCoinRepository = sellCoinRepository;
            _buyCoinValidation = buyCoinValidation;
            _sellCoinValidation = sellCoinValidation;
        }

        [HttpPost("buy")]
        public async Task<IActionResult> BuyCoinForm([FromBody] BuyCoinDto request)
        {
            try
            {
                var validationResult = _buyCoinValidation.Validate(request);

                var errorMessages = ValidationMessages.ValidationResults(validationResult);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new { message = errorMessages });
                }

                var isSuccess = await _buyCoinForCustomer.BuyCoins(request);

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
        public async Task<IActionResult> SellCoinForm([FromBody] SellCoinDto request)
        {
            try
            {
                var validationResult = _sellCoinValidation.Validate(request);

                var errorMessages = ValidationMessages.ValidationResults(validationResult);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new { message = errorMessages });
                }

                var isSuccess = await _sellCoinRepository.SellCoins(request);

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
