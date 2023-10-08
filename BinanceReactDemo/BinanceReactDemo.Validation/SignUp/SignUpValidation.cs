using BinanceReactDemo.Common.UserInformationValidationMessages.SignUpValidationMessages;
using BinanceReactDemo.DataTransferObject.Models;
using FluentValidation;

namespace BinanceReactDemo.Validation.SignUp
{
    /// <summary>
    /// Sign Up Validation
    /// </summary>
    public class SignUpValidation : AbstractValidator<SignUpDto>
    {
        /// <summary>
        /// Sign Up Validation
        /// </summary>
        public SignUpValidation()
        {
            RuleFor(dto => dto.CustomerName).NotEmpty().WithMessage(SignUpValidationMessages.CustomerNameRequired);
            RuleFor(dto => dto.CustomerEmail).NotEmpty().WithMessage(SignUpValidationMessages.CustomerEmailRequired)
                .EmailAddress().WithMessage(SignUpValidationMessages.InvalidEmailFormat);
            RuleFor(dto => dto.Username).NotEmpty().WithMessage(SignUpValidationMessages.UsernameRequired);
            RuleFor(dto => dto.Password).NotEmpty().WithMessage(SignUpValidationMessages.PasswordRequired)
                .MinimumLength(8).WithMessage(SignUpValidationMessages.PasswordMinimumLength)
                .MaximumLength(16).WithMessage(SignUpValidationMessages.PasswordMaximumLength)
                .Matches(SignUpValidationMessages.PasswordRegexMatchLetter).WithMessage(SignUpValidationMessages.PasswordUppercaseLetter)
                .Matches(SignUpValidationMessages.PasswordRegexMatchCharacter).WithMessage(SignUpValidationMessages.PasswordSpecialCharacter);
            RuleFor(dto => dto.PasswordRepeats).NotEmpty().WithMessage(SignUpValidationMessages.PasswordRepeatsRequired)
                .Equal(dto => dto.Password).WithMessage(SignUpValidationMessages.PasswordsDoNotMatch);
        }
    }
}
