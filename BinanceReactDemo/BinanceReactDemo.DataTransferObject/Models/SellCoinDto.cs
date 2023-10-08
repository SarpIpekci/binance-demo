namespace BinanceReactDemo.DataTransferObject.Models
{
    /// <summary>
    /// Represents a data transfer object (DTO) for selling a coin.
    /// </summary>
    public class SellCoinDto
    {
        /// <summary>
        /// Gets or sets the customer's unique identifier.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the coin being sold.
        /// </summary>
        public string CoinName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the value of the coin being sold.
        /// </summary>
        public double CoinValue { get; set; }

        /// <summary>
        /// Gets or sets the value at which the coin is being sold by the customer.
        /// </summary>
        public double CustomerSellValue { get; set; }

        /// <summary>
        /// Gets or sets the calculated sum of the coin sale, which is the result of multiplying the coin value by the customer's sell value.
        /// </summary>
        public double SumOfValue { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the coin sale took place (default is the current date and time).
        /// </summary>
        public DateTime SellDate { get; set; } = DateTime.Now;
    }

}
