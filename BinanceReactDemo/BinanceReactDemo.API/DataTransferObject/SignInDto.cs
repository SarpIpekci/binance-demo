namespace BinanceReactDemo.API.DataTransferObject
{
    /// <summary>
    /// Sign In DTO
    /// </summary>
    public class SignInDto
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
