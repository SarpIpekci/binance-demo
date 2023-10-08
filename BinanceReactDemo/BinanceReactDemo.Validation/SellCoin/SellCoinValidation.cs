using BinanceReactDemo.Common.UserInformationValidationMessages.SellCoinValidationMessages;
using BinanceReactDemo.DataTransferObject.Models;
using FluentValidation;

namespace BinanceReactDemo.Validation.SellCoin
{
    /// <summary>
    /// Sell Coin Validation
    /// </summary>
    public class SellCoinValidation : AbstractValidator<SellCoinDto>
    {
        /// <summary>
        /// Sell Coin Validation
        /// </summary>
        public SellCoinValidation()
        {
            RuleFor(dto => dto.CoinName).NotEmpty().WithMessage(SellCoinValidationMessages.CoinNameNull);
            RuleFor(dto => dto.CoinValue).NotEmpty()
                .WithMessage(SellCoinValidationMessages.CoinValueNull)
                .GreaterThan(0)
                .WithMessage(SellCoinValidationMessages.CoinValueGreaterThanZero);
            RuleFor(dto => dto.CustomerSellValue).NotEmpty().WithMessage(SellCoinValidationMessages.CustomerSellValueNull)
                .GreaterThan(0).WithMessage(SellCoinValidationMessages.CustomerSellValueGreaterThanZero);
            RuleFor(dto => dto.SellDate).NotEmpty().WithMessage(SellCoinValidationMessages.SellDateNull);
            RuleFor(dto => dto.CustomerId).GreaterThan(0).WithMessage(SellCoinValidationMessages.CustomerIdNull);
            RuleFor(dto => dto.SumOfValue).GreaterThanOrEqualTo(0).WithMessage(SellCoinValidationMessages.SumOfValueGreaterThanOrEqualToZero);
        }
    }
}
