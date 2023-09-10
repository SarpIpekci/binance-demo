namespace BinanceReactDemo.API.Models.SellCoin
{
    public class SellCoinModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CoinName { get; set; } = null!;
        public double CoinValue { get; set; }
        public double CustomerSellValue { get; set; }
        public string SumOfValue { get; set; } = null!;
        public DateTime SellDate { get; set; }
    }
}
