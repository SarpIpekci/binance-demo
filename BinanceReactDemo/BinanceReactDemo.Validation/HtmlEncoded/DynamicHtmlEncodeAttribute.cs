using BinanceReactDemo.Common.DynamicValidationAndEncodedErrorMessages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using System.Web;

namespace BinanceReactDemo.Validation.HtmlEncoded
{
    /// <summary>
    /// Dynamic Html Encode Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class DynamicHtmlEncodeAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Dynamic Html Encode Attribute On Action Executing
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

            if (context.ActionArguments.Count > 0)
            {
                foreach (var argument in context.ActionArguments)
                {
                    if (argument.Value != null)
                    {
                        EncodeStringProperties(argument.Value);
                    }
                }
            }

            base.OnActionExecuting(context);
        }

        private void EncodeStringProperties(object obj)
        {
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(string) && property.CanRead && property.CanWrite)
                {
                    string originalValue = (string)property.GetValue(obj);
                    if (originalValue != null)
                    {
                        string encodedValue = HttpUtility.HtmlEncode(originalValue);
                        property.SetValue(obj, encodedValue);
                    }
                }
                else if (!property.PropertyType.IsPrimitive && property.PropertyType != typeof(Guid) && property.CanRead && property.CanWrite)
                {
                    var propertyValue = property.GetValue(obj);
                    if (propertyValue != null)
                    {
                        EncodeStringProperties(propertyValue);
                    }
                }
            }
        }
    }
}
