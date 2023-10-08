namespace BinanceReactDemo.Validation
{
    /// <summary>
    /// Listed Validation Messages
    /// </summary>
    public static class ValidationMessages
    {
        /// <summary>
        /// Listed Validation Results
        /// </summary>
        /// <param name="validationResult">Validation Result</param>
        /// <returns>Listed Messages</returns>
        public static List<string> ValidationResults(FluentValidation.Results.ValidationResult? validationResult)
        {
            if (validationResult == null)
            {
                return new List<string>();
            }

            return validationResult.Errors.ConvertAll(error => error.ErrorMessage);
        }
    }
}
