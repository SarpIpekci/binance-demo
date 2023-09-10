namespace BinanceReactDemo.API.DataTransferObject
{
    public class CustomerCoinBuyTableDto
    {
        public int OperationId { get; set; }
        public string? CustomerName { get; set; }
        public string? CoinName { get; set; }
        public double CoinValue { get; set; }
        public double CustomerBuyValue { get; set; }
        public double SumOfValue { get; set; }
        public DateTime BuyDate { get; set; }
    }
}
