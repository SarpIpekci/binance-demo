using BinanceReactDemo.API.DataTransferObject;
using BinanceReactDemo.API.Repostories.SignIn_SignUp.Interface;
using BinanceReactDemo.API.Validation.SignIn;
using BinanceReactDemo.API.Validation.SignUp;
using Microsoft.AspNetCore.Mvc;
using BinanceReactDemo.API.Validation;

namespace BinanceReactDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISignInRepository _signInRepository;
        private readonly ISignUpRepository _signUpRepository;
        private readonly SignInValidation _signInValidation;
        private readonly SignUpValidation _signUpValidation;

        public LoginController(ISignInRepository signInRepository, ISignUpRepository signUpRepository, SignInValidation signInValidation, SignUpValidation signUpValidation)
        {
            _signInRepository = signInRepository;
            _signUpRepository = signUpRepository;
            _signInValidation = signInValidation;
            _signUpValidation = signUpValidation;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto request)
        {
            try
            {
                var validationResult = _signInValidation.Validate(request);

                var errorMessages = ValidationMessages.ValidationResults(validationResult);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new { message = errorMessages });
                }

                var (checkUserExists, id) = await _signInRepository.CustomerLogin(request);

                if (checkUserExists)
                {
                    return Ok(id);
                }
                else
                {
                    return BadRequest(new { message = "User is not exists" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto request)
        {
            try
            {
                var validationResult = _signUpValidation.Validate(request);

                var errorMessages = ValidationMessages.ValidationResults(validationResult);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new { message = errorMessages });
                }

                var isSuccess = await _signUpRepository.CreateCustomer(request);

                if (isSuccess)
                {
                    return Ok(new { message = "User created successfully." });
                }
                else
                {
                    return BadRequest(new { message = "Username is available." });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
