using MedWorking.Core.Common.CustomExceptionMiddleware;
using Microsoft.AspNetCore.Builder;

namespace MedWorking.Core.Common.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
