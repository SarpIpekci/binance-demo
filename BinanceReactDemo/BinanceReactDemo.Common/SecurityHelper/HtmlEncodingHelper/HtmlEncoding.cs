using System.Reflection;
using System.Web;

namespace BinanceReactDemo.Common.SecurityHelper.HtmlEncodingHelper
{
    /// <summary>
    /// Html Encoding For XSS
    /// </summary>
    public static class HtmlEncoding
    {
        private static readonly Dictionary<Type, Func<object, object>> Encoders = new()
        {
            { typeof(string), EncodeString },
            { typeof(int), value => value.ToString() },
            { typeof(DateTime), value => ((DateTime)value).ToString("o") },
            { typeof(bool), value => (bool)value ? "True" : "False" }
        };

        /// <summary>
        /// Reflection For Html Encoding
        /// </summary>
        /// <typeparam name="T">Dynamic Parameter</typeparam>
        /// <param name="model">View Model</param>
        /// <returns></returns>
        public static T EncodeModel<T>(T model)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                if (Encoders.TryGetValue(property.PropertyType, out var encoder) && property.CanRead && property.CanWrite)
                {
                    var value = property.GetValue(model);
                    var encodedValue = encoder(value!);
                    property.SetValue(model, encodedValue);
                }
                else
                {
                    var propValue = property.GetValue(model)?.ToString();
                    if (!string.IsNullOrEmpty(propValue))
                    {
                        property.SetValue(model, HttpUtility.HtmlEncode(propValue));
                    }
                }
            }

            return model;
        }

        private static object EncodeString(object value)
        {
            return HttpUtility.HtmlEncode((string)value);
        }
    }
}
