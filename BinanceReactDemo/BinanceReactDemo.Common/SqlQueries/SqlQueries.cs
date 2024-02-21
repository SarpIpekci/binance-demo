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
        public const string GetAllCoinsByIdQuery = "SELECT cus.Id AS OperationId,cus.CustomerName,buy.CoinName AS BuyCoinName,sell.CoinName AS SellCoinName,CAST(buy.CoinValue AS FLOAT) AS BuyCoinValue,CAST(sell.CoinValue AS FLOAT) AS SellCoinValue,Cast(buy.CustomerBuyValue AS FLOAT) AS BuyCustomerValue,Cast(sell.CustomerSellValue AS FLOAT) AS SellCustomerValue,Cast(buy.SumOfValue AS FLOAT) AS BuySumOfValue,Cast(sell.SumOfValue AS FLOAT) AS SellSumOfValue,(Cast(buy.SumOfValue AS FLOAT) - Cast(sell.SumOfValue AS FLOAT)) AS [Differences],buy.BuyDate,sell.SellDate FROM BuyCoin AS buy WITH (NOLOCK) INNER JOIN SellCoin AS sell ON buy.CustomerId = sell.CustomerId INNER JOIN Customer AS cus ON buy.CustomerId = cus.Id WHERE buy.CustomerId = @customerId ORDER BY buy.BuyDate DESC, sell.SellDate DESC";

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
