using BinanceReactDemo.Common.UserInformationValidationMessages.BuyCoinValidationMessages;
using BinanceReactDemo.DataTransferObject.Models;
using FluentValidation;

namespace BinanceReactDemo.Validation.BuyCoin
{
    /// <summary>
    /// Buy Coin Validation
    /// </summary>
    public class BuyCoinValidation : AbstractValidator<BuyCoinDto>
    {
        /// <summary>
        /// Buy Coin Validation
        /// </summary>
        public BuyCoinValidation()
        {
            RuleFor(dto => dto.CoinName).NotEmpty().WithMessage(BuyCoinValidationMessages.CoinNameNull);
            RuleFor(dto => dto.CoinValue).NotEmpty()
                .WithMessage(BuyCoinValidationMessages.CoinValueNull)
                .GreaterThan(0)
                .WithMessage(BuyCoinValidationMessages.CoinValueGreaterThanZero);
            RuleFor(dto => dto.CustomerBuyValue).NotEmpty().WithMessage(BuyCoinValidationMessages.CustomerBuyValueNull)
                .GreaterThan(0).WithMessage(BuyCoinValidationMessages.CustomerBuyValueNull);
            RuleFor(dto => dto.BuyDate).NotEmpty().WithMessage(BuyCoinValidationMessages.BuyDateNull);
            RuleFor(dto => dto.CustomerId).GreaterThan(0).WithMessage(BuyCoinValidationMessages.CustomerIdNull);
            RuleFor(dto => dto.SumOfValue).GreaterThanOrEqualTo(-1).WithMessage(BuyCoinValidationMessages.SumOfValueGreaterThanOrEqualToZero);
        }
    }
}
