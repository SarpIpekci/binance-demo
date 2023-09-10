using BinanceReactDemo.API.DataTransferObject;
using FluentValidation;

namespace BinanceReactDemo.API.Validation.SellCoin
{
    public class SellCoinValidation : AbstractValidator<SellCoinDto>
    {
        public SellCoinValidation()
        {
            RuleFor(dto => dto.CoinName).NotEmpty().WithMessage("Coin name is required");
            RuleFor(dto => dto.CoinValue).NotEmpty()
                .WithMessage("Coin value is required")
                .GreaterThan(0)
                .WithMessage("Coin value must be greater than 0");
            RuleFor(dto => dto.CustomerSellValue).NotEmpty().WithMessage("Customer sell value is required")
                .GreaterThan(0).WithMessage("Customer sell value must be greater than 0");
            RuleFor(dto => dto.SellDate).NotEmpty().WithMessage("Sell date is required");
            RuleFor(dto => dto.CustomerId).GreaterThan(0).WithMessage("Invalid customer ID");
        }
    }
}
