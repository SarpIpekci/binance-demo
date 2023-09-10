using BinanceReactDemo.API.DataTransferObject;
using BinanceReactDemo.API.Models.BuyCoin;
using BinanceReactDemo.API.Models.SellCoin;
using BinanceReactDemo.API.Repostories.BuyCoin.Interfaces;
using BinanceReactDemo.API.Repostories.SellCoin.Interfaces;
using BinanceReactDemo.API.Validation;
using BinanceReactDemo.API.Validation.BuyCoin;
using BinanceReactDemo.API.Validation.SellCoin;
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

                var generateCoin = new BuyCoinModel
                {
                    CustomerId = request.CustomerId,
                    CoinName = request.CoinName,
                    CoinValue = request.CoinValue,
                    CustomerBuyValue = request.CustomerBuyValue,
                    SumOfValue = (request.CoinValue * request.CustomerBuyValue).ToString(),
                    BuyDate = request.BuyDate,
                };

                var isSuccess = await _buyCoinForCustomer.BuyCoins(generateCoin);

                if (isSuccess)
                {
                    return Ok(new { message = "Coin is buying" });
                }
                else
                {
                    return BadRequest(new { message = "Could not buy coins" });
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

                var generateModel = new SellCoinModel
                {
                    CustomerId = request.CustomerId,
                    CoinName = request.CoinName,
                    CoinValue = request.CoinValue,
                    CustomerSellValue = request.CustomerSellValue,
                    SumOfValue = (request.CoinValue * request.CustomerSellValue).ToString(),
                    SellDate = request.SellDate,
                };

                var isSuccess = await _sellCoinRepository.SellCoins(generateModel);

                if (isSuccess)
                {
                    return Ok(new { message = "Coin is selling" });
                }
                else
                {
                    return BadRequest(new { message = "Could not sell coins" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
