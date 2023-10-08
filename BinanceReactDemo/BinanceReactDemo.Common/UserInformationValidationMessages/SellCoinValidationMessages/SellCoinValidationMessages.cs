using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanceReactDemo.Common.UserInformationValidationMessages.SellCoinValidationMessages
{
    /// <summary>
    /// This class contains validation rules for a coin sale transaction made by a customer.
    /// </summary>
    public static class SellCoinValidationMessages
    {
        /// <summary>
        /// Coin name is required.
        /// </summary>
        public const string CoinNameNull = "Coin name is required.";

        /// <summary>
        /// Coin value is required.
        /// </summary>
        public const string CoinValueNull = "Coin value is required.";

        /// <summary>
        /// Coin value must be greater than zero.
        /// </summary>
        public const string CoinValueGreaterThanZero = "Coin value must be greater than zero.";

        /// <summary>
        /// Customer sell value is required.
        /// </summary>
        public const string CustomerSellValueNull = "Customer sell value is required.";

        /// <summary>
        /// Customer sell value must be greater than zero.
        /// </summary>
        public const string CustomerSellValueGreaterThanZero = "Customer sell value must be greater than zero.";

        /// <summary>
        /// Sell date is required.
        /// </summary>
        public const string SellDateNull = "Sell date is required.";

        /// <summary>
        /// Invalid customer ID.
        /// </summary>
        public const string CustomerIdNull = "Invalid customer ID.";

        /// <summary>
        /// The principal cannot be less than or equal zero.
        /// </summary>
        public const string SumOfValueGreaterThanOrEqualToZero = "The principal cannot be less than or equal zero.";
    }
}
