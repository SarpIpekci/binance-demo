namespace BinanceReactDemo.API.DataTransferObject
{
    public class CustomerCoinSellTableDto
    {
        public int OperationId { get; set; }
        public string? CustomerName { get; set; }
        public string? CoinName { get; set; }
        public double CoinValue { get; set; }
        public double CustomerSellValue { get; set; }
        public double SumOfValue { get; set; }
        public DateTime SellDate { get; set; }
    }
}
