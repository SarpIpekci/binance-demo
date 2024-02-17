using BinanceReactDemo.Common.DynamicValidationAndEncodedErrorMessages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BinanceReactDemo.Validation.XSSControl
{
    /// <summary>
    /// Dynamic XSS Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class DynamicXssControlAttribute: ActionFilterAttribute
    {
        private const string pattern = @"('|""|--|\/\*|\*\/|;|\b(ALTER|CREATE|DELETE|DROP|SELECT|INSERT|UPDATE|TRUNCATE|REPLACE|GRANT|REVOKE|LOAD|CALL)\b)";

        /// <summary>
        /// Dynamic XSS Attribute
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.Any())
            {
                context.Result = new BadRequestObjectResult(new { message = DynamicAttributeErrorMessages.RequestIsMissing });
                return;
            }

            foreach (var actionArguments in context.ActionArguments.Values)
            {
                if (actionArguments != null && IsMatchFoundInAnyProperty(actionArguments, pattern))
                {
                    context.Result = new BadRequestObjectResult(new { message = DynamicAttributeErrorMessages.InvalidInputDetected });
                    return;
                }
            }

            base.OnActionExecuting(context);
        }

        private bool IsMatchFoundInAnyProperty(object obj, string pattern)
        {
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                if (property.CanRead)
                {
                    var propertyValue = property.GetValue(obj);
                    if (propertyValue != null)
                    {
                        if (property.PropertyType == typeof(string))
                        {
                            var stringValue = (string)propertyValue;
                            if (Regex.IsMatch(stringValue, pattern, RegexOptions.IgnoreCase))
                            {
                                return true;
                            }
                        }
                        else if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                        {
                            if (!IsMatchFoundInAnyProperty(propertyValue, pattern))
                            {
                                continue;
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
