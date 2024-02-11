using BinanceReactDemo.DataTransferObject.Models;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using System.Net;
using System.Text.Json;

namespace BinanceReactDemo.API.Test
{
    /// <summary>
    /// Exception Middleware Extensions
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Configure Exception Handler
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var error = contextFeature.Error;
                        var errorLog = new ErrorLogModel
                        {
                            PostDate = DateTime.Now,
                            Message = error.Message,
                            Controller = GetControllerName(contextFeature),
                            Action = GetActionName(contextFeature),
                            Method = context.Request.Method,
                            StatusCode = GetStatusCode(context),
                            IPAdress = context.Connection.RemoteIpAddress?.ToString()
                        };

                        Log.Error(error, "An error occurred: {@ErrorLog}", errorLog);

                        var result = JsonSerializer.Serialize(new { error = "Internal Server Error." });
                        await context.Response.WriteAsync(result);
                    }
                });
            });
        }

        private static string? GetControllerName(IExceptionHandlerFeature contextFeature)
        {
            return ((RouteEndpoint)((ExceptionHandlerFeature)contextFeature).Endpoint).RoutePattern.Defaults.Values.ToArray()[1]?.ToString();
        }

        private static string? GetActionName(IExceptionHandlerFeature contextFeature)
        {
            return ((RouteEndpoint)((ExceptionHandlerFeature)contextFeature).Endpoint).RoutePattern.Defaults.Values.ToArray()[0]?.ToString();
        }

        private static int? GetStatusCode(HttpContext context)
        {
            return ((DefaultHttpContext)context).Response.StatusCode;
        }
    }
}
