using BinanceReactDemo.API.DataTransferObject;
using FluentValidation;

namespace BinanceReactDemo.API.Validation.SignIn
{
    /// <summary>
    /// Sign In Validation
    /// </summary>
    public class SignInValidation:AbstractValidator<SignInDto>
    {
        /// <summary>
        /// Sign In Validation
        /// </summary>
        public SignInValidation()
        {
            RuleFor(dto => dto.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(dto => dto.Password).NotEmpty().WithMessage("Password is required")
             .MinimumLength(8).WithMessage("Password must be at least 8 characters")
             .MaximumLength(8).WithMessage("Password can't be longer than 8 characters")
             .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
             .Matches("[!@#$%^&*(),.?\":{}|<>]").WithMessage("Password must contain at least one special character");
        }
    }
}
