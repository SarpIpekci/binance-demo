using BinanceReactDemo.API.DataTransferObject;
using FluentValidation;

namespace BinanceReactDemo.API.Validation.SignUp
{
    /// <summary>
    /// Sign Up Validation
    /// </summary>
    public class SignUpValidation: AbstractValidator<SignUpDto>
    {
        /// <summary>
        /// Sign Up Validation
        /// </summary>
        public SignUpValidation()
        {
            RuleFor(dto => dto.CustomerName).NotEmpty().WithMessage("Customer name is required");
            RuleFor(dto => dto.CustomerEmail).NotEmpty().WithMessage("Customer email is required")
                .EmailAddress().WithMessage("Invalid email format");
            RuleFor(dto => dto.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(dto => dto.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters")
                .MaximumLength(8).WithMessage("Password can't be longer than 8 characters")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches("[!@#$%^&*(),.?\":{}|<>]").WithMessage("Password must contain at least one special character");
            RuleFor(dto => dto.PasswordRepeats).NotEmpty().WithMessage("Password repeat is required")
                .Equal(dto => dto.Password).WithMessage("Passwords do not match");
        }
    }
}
