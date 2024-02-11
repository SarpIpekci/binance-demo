using BinanceReactDemo.Common.DynamicValidationAndEncodedErrorMessages;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BinanceReactDemo.Validation.DynamicValidationAndEncoded
{
    /// <summary>
    /// Dynamic Validation Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class DynamicValidationAttribute : ActionFilterAttribute
    {
        private readonly Type _validatorType;
        private const string validate = "Validate";

        /// <summary>
        /// Dynamic Validation Attribute
        /// </summary>
        /// <param name="validatorType">Validator Type</param>
        public DynamicValidationAttribute(Type validatorType)
        {
            _validatorType = validatorType;
        }

        /// <summary>
        /// Dynamic Validation Attribute On Action Executing
        /// </summary>
        /// <param name="context">Action Executing Context</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.ActionArguments["request"];

            if (request == null)
            {
                context.Result = new BadRequestObjectResult(new { message = DynamicAttributeErrorMessages.RequestIsMissing });
                return;
            }

            var validationResultMethod = _validatorType.GetMethod(validate, new Type[] { request.GetType() });

            if (validationResultMethod == null)
            {
                context.Result = new BadRequestObjectResult(new { message = DynamicAttributeErrorMessages.InvalidOperatorType });
                return;
            }

            var validationResult = validationResultMethod.Invoke(Activator.CreateInstance(_validatorType), new object[] { request });

            if (validationResult != null && validationResult.GetType() == typeof(ValidationResult))
            {
                var errors = ((ValidationResult)validationResult).Errors.Select(error => error.ErrorMessage);

                if (errors.Any())
                {
                    context.Result = new BadRequestObjectResult(new { message = errors });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
