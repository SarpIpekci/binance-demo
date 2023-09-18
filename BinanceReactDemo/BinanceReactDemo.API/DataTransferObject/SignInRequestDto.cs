namespace BinanceReactDemo.API.DataTransferObject
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
        /// Customer username.
        /// </summary>
        public string Username { get; set; }
    }
}
