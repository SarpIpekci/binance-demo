namespace BinanceReactDemo.Common.SqlQueries
{
    /// <summary>
    /// All Sql Queries
    /// </summary>
    public static class SqlQueries
    {
        /// <summary>
        /// Buy Coins Query
        /// </summary>
        public const string BuyCoinsQuery = "INSERT INTO BuyCoin(CustomerId,CoinName,CoinValue,CustomerBuyValue,SumOfValue,BuyDate) VALUES(@customerId,@coinName,@coinValue,@customerBuyValue,@sumOfValue,@buyDate)";

        /// <summary>
        /// Get All Coins By Id Query
        /// </summary>
        public const string GetAllCoinsByIdQuery = "select cus.Id as OperationId,cus.CustomerName,buy.CoinName as BuyCoinName,sell.CoinName as SellCoinName,CAST(buy.CoinValue AS float) as BuyCoinValue,CAST(sell.CoinValue as float) as SellCoinValue,Cast(buy.CustomerBuyValue as float) as BuyCustomerValue,Cast(sell.CustomerSellValue as float) as SellCustomerValue,Cast(buy.SumOfValue as float) as BuySumOfValue,Cast(sell.SumOfValue as float) as SellSumOfValue,(Cast(buy.SumOfValue as float) - Cast(sell.SumOfValue as float)) as [Differences],buy.BuyDate,sell.SellDate from BuyCoin as buy WITH (NOLOCK) Inner Join SellCoin as sell on buy.CustomerId = sell.CustomerId Inner Join Customer as cus on buy.CustomerId = cus.Id Where buy.CustomerId = @customerId order by OperationId desc";

        /// <summary>
        /// Get Buy Coins By Id Query
        /// </summary>
        public const string GetBuyCoinsByIdQuery = "SELECT buy.Id as OperationId,cus.CustomerName,buy.CoinName,Cast(buy.CoinValue as float) as CoinValue,Cast(buy.CustomerBuyValue as float) as CustomerBuyValue,Cast(buy.SumOfValue as float) as SumOfValue,buy.BuyDate from BuyCoin as buy WITH (NOLOCK) Inner Join Customer as cus on buy.CustomerId = cus.Id Where buy.CustomerId = @customerId order by OperationId desc";

        /// <summary>
        /// Get Sell Coins By Id Query
        /// </summary>
        public const string GetSellCoinsByIdQuery = "SELECT sell.Id as OperationId,cus.CustomerName,sell.CoinName,Cast(sell.CoinValue as float) as CoinValue,Cast(sell.CustomerSellValue as float) as CustomerSellValue,Cast(sell.SumOfValue as float) as SumOfValue,sell.SellDate from SellCoin as sell WITH (NOLOCK) Inner Join Customer as cus on sell.CustomerId = cus.Id Where sell.CustomerId = @customerId order by OperationId desc";

        /// <summary>
        /// Sell Coins Query
        /// </summary>
        public const string SellCoinsQuery = "INSERT INTO SellCoin(CustomerId,CoinName,CoinValue,CustomerSellValue,SumOfValue,SellDate) VALUES(@customerId,@coinName,@coinValue,@customerSellValue,@sumOfValue,@sellDate)";

        /// <summary>
        /// Check Username Query
        /// </summary>
        public const string CheckUsernameQuery = "SELECT COUNT(*) FROM Customer WHERE Username = @username AND PasswordHash = @password";

        /// <summary>
        /// Customer Id Query
        /// </summary>
        public const string CustomerIdQuery = "SELECT Id, Username, CustomerName FROM Customer WHERE Username = @username AND PasswordHash = @password";

        /// <summary>
        /// Check Username Sign Up Query
        /// </summary>
        public const string CheckUsernameSignUpQuery = "SELECT COUNT(*) FROM Customer WHERE Username = @username";

        /// <summary>
        /// Create Customer Query
        /// </summary>
        public const string CreateCustomerQuery = "INSERT INTO Customer(CustomerName,CustomerEmail,Username,PasswordHash,PasswordRepeatHash,CreatedDate) VALUES(@customerName,@customerEmail,@username,@password,@passwordRepeat,@createdDate)";
    }
}
