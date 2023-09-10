namespace BinanceReactDemo.API.DataTransferObject
{
    public class SellCoinDto
    {
        public int CustomerId { get; set; }
        public string CoinName { get; set; } = null!;
        public double CoinValue { get; set; }
        public double CustomerSellValue { get; set; }
        public DateTime SellDate { get; set; }
    }
}
