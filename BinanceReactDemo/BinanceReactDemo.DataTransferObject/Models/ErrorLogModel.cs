namespace BinanceReactDemo.DataTransferObject.Models
{
    /// <summary>
    /// Error Log Model
    /// </summary>
    public class ErrorLogModel
    {
        /// <summary>
        /// Message
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Controller
        /// </summary>
        public string? Controller { get; set; }

        /// <summary>
        /// Action
        /// </summary>
        public string? Action { get; set; }

        /// <summary>
        /// Method
        /// </summary>
        public string? Method { get; set; }

        /// <summary>
        /// Service
        /// </summary>
        public string? Service { get; set; }

        /// <summary>
        /// PostDate
        /// </summary>
        public DateTime PostDate { get; set; }

        /// <summary>
        /// StatusCode
        /// </summary>
        public int? StatusCode { get; set; }

        /// <summary>
        /// IPAdress
        /// </summary>
        public string? IPAdress { get; set; }
    }
}
