using BinanceReactDemo.Business.Abstract.SignIn;
using BinanceReactDemo.Business.Abstract.SignUp;
using BinanceReactDemo.Common.UserInformatiomErrorMessages;
using BinanceReactDemo.Common.UserInformationMessages;
using BinanceReactDemo.DataTransferObject.Models;
using BinanceReactDemo.Validation.DynamicValidationAndEncoded;
using BinanceReactDemo.Validation.SignIn;
using BinanceReactDemo.Validation.SignUp;
using BinanceReactDemo.Validation.XSSControl;
using Microsoft.AspNetCore.Mvc;

namespace BinanceReactDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISignInService _signInService;
        private readonly ISignUpService _signUpService;

        public LoginController(ISignInService signInService, ISignUpService signUpService)
        {
            _signInService = signInService;
            _signUpService = signUpService;
        }

        [HttpPost("signIn")]
        [DynamicValidation(typeof(SignInValidation))]
        [DynamicXssControl]
        public async Task<IActionResult> SignIn([FromBody] SignInDto request)
        {
            if (request.Username.Equals("sarp"))
            {
                throw new Exception("test");
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

        [HttpPost("signUp")]
        [DynamicValidation(typeof(SignUpValidation))]
        [DynamicXssControl]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto request)
        {
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
    }
}
