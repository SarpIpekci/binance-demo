namespace BinanceReactDemo.API.Models.SignIn_SignUp
{
    /// <summary>
    /// Sign Up
    /// </summary>
    public class SignUp
    {
        /// <summary>
        /// Customer Name
        /// </summary>
        public string CustomerName { get; set; } = null!;

        /// <summary>
        /// Customer Email
        /// </summary>
        public string CustomerEmail { get; set; } = null!;
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Password Repeat
        /// </summary>
        public string PasswordRepeats { get; set; } = null!;
    }
}
