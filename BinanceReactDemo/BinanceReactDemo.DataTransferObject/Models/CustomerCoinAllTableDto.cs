namespace BinanceReactDemo.DataTransferObject.Models
{
    /// <summary>
    /// Customer Coin All Table Dto
    /// </summary>
    public class CustomerCoinAllTableDto
    {
        /// <summary>
        /// Operation Id
        /// </summary>
        public int OperationId { get; set; }

        /// <summary>
        /// Gets or sets the customer's name.
        /// </summary>
        public string CustomerName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the coin being bought.
        /// </summary>
        public string BuyCoinName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the coin being sold.
        /// </summary>
        public string SellCoinName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the value of the bought coin.
        /// </summary>
        public double BuyCoinValue { get; set; }

        /// <summary>
        /// Gets or sets the value of the sold coin.
        /// </summary>
        public double SellCoinValue { get; set; }

        /// <summary>
        /// Gets or sets the customer's buy value.
        /// </summary>
        public double BuyCustomerValue { get; set; }

        /// <summary>
        /// Gets or sets the customer's sell value.
        /// </summary>
        public double SellCustomerValue { get; set; }

        /// <summary>
        /// Gets or sets the sum of the bought coin's value.
        /// </summary>
        public double BuySumOfValue { get; set; }

        /// <summary>
        /// Gets or sets the sum of the sold coin's value.
        /// </summary>
        public double SellSumOfValue { get; set; }

        /// <summary>
        /// Gets or sets the difference between buy and sell values.
        /// </summary>
        public double Differences { get; set; }

        /// <summary>
        /// Gets or sets the date of the coin purchase.
        /// </summary>
        public DateTime BuyDate { get; set; }

        /// <summary>
        /// Gets or sets the date of the coin sale.
        /// </summary>
        public DateTime SellDate { get; set; }
    }
}