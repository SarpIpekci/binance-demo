namespace BinanceReactDemo.API.Models.CustomerCoinTable
{
    public class CustomerCoinTableDto
    {
        public string CustomerName { get; set; } = null!;
        public string BuyCoinName { get; set; } = null!;
        public string SellCoinName { get; set; } = null!;
        public string BuyCoinValue { get; set; } = null!;
        public string SellCoinValue { get; set; } = null!;
        public string BuyCustomerValue { get; set; } = null!;
        public string SellCustomerValue { get; set; } = null!;
        public double BuySumOfValue { get; set; }
        public double SellSumOfValue { get; set; }
        public double Differences { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
    }
}
