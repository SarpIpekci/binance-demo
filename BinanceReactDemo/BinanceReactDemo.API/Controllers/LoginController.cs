using BinanceReactDemo.Business.Abstract.SignIn;
using BinanceReactDemo.Business.Abstract.SignUp;
using BinanceReactDemo.Common.SecurityHelper.HtmlEncodingHelper;
using BinanceReactDemo.Common.UserInformatiomErrorMessages;
using BinanceReactDemo.Common.UserInformationMessages;
using BinanceReactDemo.DataTransferObject.Models;
using BinanceReactDemo.Validation.DynamicValidationAndEncoded;
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

        public LoginController(ISignInService signInService, ISignUpService signUpService)
        {
            _signInService = signInService;
            _signUpService = signUpService;
        }

        [HttpPost("signIn")]
        [DynamicValidation(typeof(SignInValidation))]
        public async Task<IActionResult> SignIn([FromBody] SignInDto request)
        {
            try
            {
                var encodingModel = HtmlEncoding.EncodeModel(request);

                var exits = await _signInService.CheckCustomerExits(encodingModel);

                if (exits)
                {
                    var result = await _signInService.CustomerLogin(encodingModel);

                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = UserInformationErrorMessages.SignInError });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpPost("signUp")]
        [DynamicValidation(typeof(SignUpValidation))]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto request)
        {
            try
            {
                var encodingModel = HtmlEncoding.EncodeModel(request);

                var isSuccess = await _signUpService.CreateCustomer(encodingModel);

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
