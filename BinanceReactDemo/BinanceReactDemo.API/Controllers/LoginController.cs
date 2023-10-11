using BinanceReactDemo.Business.Abstract.SignIn;
using BinanceReactDemo.Business.Abstract.SignUp;
using BinanceReactDemo.Common.UserInformatiomErrorMessages;
using BinanceReactDemo.Common.UserInformationMessages;
using BinanceReactDemo.DataTransferObject.Models;
using BinanceReactDemo.Validation;
using BinanceReactDemo.Validation.SignIn;
using BinanceReactDemo.Validation.SignUp;
using Microsoft.AspNetCore.Mvc;

namespace BinanceReactDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISignInService _signInService;
        private readonly ISignUpService _signUpService;
        private readonly SignUpValidation _signUpValidation;
        private readonly SignInValidation _signInValidation;

        private const string _exception = "exception";

        public LoginController(ISignInService signInService, ISignUpService signUpService, SignUpValidation signUpValidation, SignInValidation signInValidation)
        {
            _signInService = signInService;
            _signUpService = signUpService;
            _signUpValidation = signUpValidation;
            _signInValidation = signInValidation;
        }

        [HttpPost("signIn")]
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

                var exits = await _signInService.CheckCustomerExits(request);

                if (exits)
                {
                    var result = await _signInService.CustomerLogin(request);

                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = UserInformationErrorMessages.SignInError });
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

                var isSuccess = await _signUpService.CreateCustomer(request);

                if (isSuccess)
                {
                    return Ok(new { message = UserInformationMessages.SignUpUser });
                }
                else
                {
                    return BadRequest(new { message = UserInformationErrorMessages.SignUpError });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
