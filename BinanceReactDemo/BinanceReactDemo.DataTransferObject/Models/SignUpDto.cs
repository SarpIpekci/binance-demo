namespace BinanceReactDemo.DataTransferObject.Models
{
    /// <summary>
    /// Sign Up Dto
    /// </summary>
    public class SignUpDto
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
