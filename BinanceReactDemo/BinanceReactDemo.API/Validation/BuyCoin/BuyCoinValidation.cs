using BinanceReactDemo.API.DataTransferObject;
using FluentValidation;

namespace BinanceReactDemo.API.Validation.BuyCoin
{
    public class BuyCoinValidation : AbstractValidator<BuyCoinDto>
    {
        public BuyCoinValidation()
        {
            RuleFor(dto => dto.CoinName).NotEmpty().WithMessage("Coin name is required");
            RuleFor(dto => dto.CoinValue).NotEmpty()
                .WithMessage("Coin value is required")
                .GreaterThan(0)
                .WithMessage("Coin value must be greater than 0");
            RuleFor(dto => dto.CustomerBuyValue).NotEmpty().WithMessage("Customer buy value is required")
                .GreaterThan(0).WithMessage("Customer buy value must be greater than 0");
            RuleFor(dto => dto.BuyDate).NotEmpty().WithMessage("Buy date is required");
            RuleFor(dto => dto.CustomerId).GreaterThan(0).WithMessage("Invalid customer ID");
            RuleFor(dto => dto.SumOfValue).GreaterThan(0).WithMessage("Test");
        }
    }
}
