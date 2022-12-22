using Microsoft.AspNetCore.Http;

namespace MedWorking.Core.Common.Static;

public static class GeneralEx
{
    internal static readonly char[] chars =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
    public static string GetUserId(this HttpContext httpContext)
    {
        if (httpContext == null)
        {
            return string.Empty;
        }
        else
        {
            return httpContext.User.Claims.Single(x => x.Type == "Id").Value;
        }
    }
}
