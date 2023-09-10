namespace BinanceReactDemo.API.DataTransferObject
{
    public class CustomerCoinAllTableDto
    {
        public string CustomerName { get; set; } = null!;
        public string BuyCoinName { get; set; } = null!;
        public string SellCoinName { get; set; } = null!;
        public double BuyCoinValue { get; set; }
        public double SellCoinValue { get; set; }
        public double BuyCustomerValue { get; set; }
        public double SellCustomerValue { get; set; }
        public double BuySumOfValue { get; set; }
        public double SellSumOfValue { get; set; }
        public double Differences { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
    }
}
