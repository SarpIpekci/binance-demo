using BinanceReactDemo.API.DataTransferObject;
using BinanceReactDemo.API.Repostories.SignIn_SignUp.Interface;
using BinanceReactDemo.API.Validation;
using BinanceReactDemo.API.Validation.SignUp;
using Microsoft.AspNetCore.Mvc;

namespace BinanceReactDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISignInRepository _signInRepository;
        private readonly ISignUpRepository _signUpRepository;
        private readonly SignUpValidation _signUpValidation;

        private const string _validation = "validation";
        private const string _exception = "exception";

        public LoginController(ISignInRepository signInRepository, ISignUpRepository signUpRepository, SignUpValidation signUpValidation)
        {
            _signInRepository = signInRepository;
            _signUpRepository = signUpRepository;
            _signUpValidation = signUpValidation;
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto request)
        {
            try
            {
                var (checkUserExists, result) = await _signInRepository.CustomerLogin(request);

                if (checkUserExists)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = "Username or Password is wrong." });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message, errorCode = _exception });
            }
        }

        [HttpPost("signUp")]
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
                    return BadRequest(new { message = "User is available." });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
