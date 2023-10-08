using BinanceReactDemo.Common.UserInformationValidationMessages.SignInValidationMessages;
using BinanceReactDemo.DataTransferObject.Models;
using FluentValidation;

namespace BinanceReactDemo.Validation.SignIn
{
    /// <summary>
    /// Sign In Validation
    /// </summary>
    public class SignInValidation : AbstractValidator<SignInDto>
    {
        /// <summary>
        /// Sign In Validation
        /// </summary>
        public SignInValidation()
        {
            RuleFor(model => model.Username)
           .NotEmpty()
           .When(model => string.IsNullOrWhiteSpace(model.Password))
           .WithMessage(SignInValidationMessages.UsernameOrPasswordRequired);

            RuleFor(model => model.Password)
                .NotEmpty()
                .When(model => string.IsNullOrWhiteSpace(model.Username))
                .WithMessage(SignInValidationMessages.UsernameOrPasswordRequired);
        }
    }
}
