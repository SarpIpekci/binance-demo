namespace BinanceReactDemo.API.Validation
{
    public static class ValidationMessages
    {
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
