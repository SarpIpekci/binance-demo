namespace BinanceReactDemo.API.Models.BuyCoin
{
    /// <summary>
    /// Buy Coin
    /// </summary>
    public class BuyCoinModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Customer Id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Coin Name
        /// </summary>
        public string CoinName { get; set; } = null!;

        /// <summary>
        /// Coin Value
        /// </summary>
        public double CoinValue { get; set; }

        /// <summary>
        /// Customer Buy Value
        /// </summary>
        public double CustomerBuyValue { get; set; }

        /// <summary>
        /// Sum Of Value
        /// </summary>
        public string SumOfValue { get; set; } = null!;

        /// <summary>
        /// Buy Date
        /// </summary>
        public DateTime BuyDate { get; set; } = DateTime.Now;
    }
}
