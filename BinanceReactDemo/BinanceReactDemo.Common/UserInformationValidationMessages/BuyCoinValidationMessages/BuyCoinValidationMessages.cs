namespace BinanceReactDemo.Common.UserInformationValidationMessages.BuyCoinValidationMessages
{
    /// <summary>
    /// This class contains validation rules for a coin purchase transaction made by a customer.
    /// </summary>
    public static class BuyCoinValidationMessages
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
        /// Customer buy value is required.
        /// </summary>
        public const string CustomerBuyValueNull = "Customer buy value is required.";

        /// <summary>
        /// Customer buy value must be greater than zero.
        /// </summary>
        public const string CustomerBuyValueGreaterThanZero = "Customer buy value must be greater than zero.";

        /// <summary>
        /// Buy date is required.
        /// </summary>
        public const string BuyDateNull = "Buy date is required.";

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
