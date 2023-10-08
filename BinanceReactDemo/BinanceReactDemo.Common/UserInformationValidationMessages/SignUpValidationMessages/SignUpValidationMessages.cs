namespace BinanceReactDemo.Common.UserInformationValidationMessages.SignUpValidationMessages
{
    /// <summary>
    /// This class contains validation rules for user sign-up.
    /// </summary>
    /// <summary>
    /// This class contains validation rules for user sign-up.
    /// </summary>
    public static class SignUpValidationMessages
    {
        /// <summary>
        /// Customer name is required.
        /// </summary>
        public const string CustomerNameRequired = "Customer name is required.";

        /// <summary>
        /// Customer email is required.
        /// </summary>
        public const string CustomerEmailRequired = "Customer email is required.";

        /// <summary>
        /// Invalid email format.
        /// </summary>
        public const string InvalidEmailFormat = "Invalid email format.";

        /// <summary>
        /// Username is required.
        /// </summary>
        public const string UsernameRequired = "Username is required.";

        /// <summary>
        /// Password is required.
        /// </summary>
        public const string PasswordRequired = "Password is required.";

        /// <summary>
        /// Password must be at least 8 characters.
        /// </summary>
        public const string PasswordMinimumLength = "Password must be at least 8 characters.";

        /// <summary>
        /// Password can't be longer than 16 characters.
        /// </summary>
        public const string PasswordMaximumLength = "Password can't be longer than 16 characters.";

        /// <summary>
        /// Password must contain at least one uppercase letter.
        /// </summary>
        public const string PasswordUppercaseLetter = "Password must contain at least one uppercase letter.";

        /// <summary>
        /// Password must contain at least one special character.
        /// </summary>
        public const string PasswordSpecialCharacter = "Password must contain at least one special character.";

        /// <summary>
        /// Passwords do not match.
        /// </summary>
        public const string PasswordsDoNotMatch = "Passwords do not match.";

        /// <summary>
        /// Password repeats are required.
        /// </summary>
        public const string PasswordRepeatsRequired = "Password repeats are required.";

        /// <summary>
        /// Password Regex Match Letter [A-Z]
        /// </summary>
        public const string PasswordRegexMatchLetter = "[A-Z]";

        /// <summary>
        /// Password Regex Match Character [!@#$%^&*(),.?\":{}|<>]
        /// </summary>
        public const string PasswordRegexMatchCharacter = "[!@#$%^&*(),.?\":{}|<>]";
    }
}
