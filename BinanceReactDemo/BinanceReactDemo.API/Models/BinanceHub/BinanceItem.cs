namespace BinanceReactDemo.API.Models.BinanceHub
{
    /// <summary>
    /// Binance Items Class.
    /// </summary>
    public class BinanceItem
    {
        /// <summary>
        /// Coin Symbols Or Name.
        /// </summary>
        public string Symbol { get; set; } = null!;

        /// <summary>
        /// Coin Value.
        /// </summary>
        public string Price { get; set; } = null!;
    }
}
