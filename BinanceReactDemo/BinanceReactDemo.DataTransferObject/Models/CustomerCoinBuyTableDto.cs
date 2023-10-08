namespace BinanceReactDemo.DataTransferObject.Models
{
    /// <summary>
    /// DTO (Data Transfer Object) class used for the customer's coin purchase table.
    /// </summary>
    public class CustomerCoinBuyTableDto
    {
        /// <summary>
        /// Operation identifier.
        /// </summary>
        public int OperationId { get; set; }

        /// <summary>
        /// Customer name.
        /// </summary>
        public string? CustomerName { get; set; }

        /// <summary>
        /// Coin name.
        /// </summary>
        public string? CoinName { get; set; }

        /// <summary>
        /// Coin value.
        /// </summary>
        public double CoinValue { get; set; }

        /// <summary>
        /// Customer purchase value.
        /// </summary>
        public double CustomerBuyValue { get; set; }

        /// <summary>
        /// Sum of values.
        /// </summary>
        public double SumOfValue { get; set; }

        /// <summary>
        /// Purchase date.
        /// </summary>
        public DateTime BuyDate { get; set; }
    }

}
