namespace BinanceReactDemo.DataTransferObject.Models
{
    /// <summary>
    /// Sign In Request Dto
    /// </summary>
    public class SignInRequestDto
    {
        /// <summary>
        /// Customer Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Customer Username.
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Customer Name.
        /// </summary>
        public string CustomerName { get; set; } = null!;
    }
}
