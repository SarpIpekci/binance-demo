namespace BinanceReactDemo.API.DataTransferObject
{
    /// <summary>
    /// Buy Coin Dto
    /// </summary>
    public class BuyCoinDto
    {
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
        /// Buy Date
        /// </summary>
        public DateTime BuyDate { get; set; } = DateTime.Now;
    }
}
