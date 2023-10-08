namespace BinanceReactDemo.DataTransferObject.Models
{
    /// <summary>
    /// DTO (Data Transfer Object) class used for the customer's coin sell table.
    /// </summary>
    public class CustomerCoinSellTableDto
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
        /// Customer sell value.
        /// </summary>
        public double CustomerSellValue { get; set; }

        /// <summary>
        /// Sum of values.
        /// </summary>
        public double SumOfValue { get; set; }

        /// <summary>
        /// Sell date.
        /// </summary>
        public DateTime SellDate { get; set; }
    }

}
