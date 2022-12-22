namespace MedWorking.Core.Common.Static;

public static class GetCurrentAuthen
{
    private static string userName = string.Empty;
    private static string appCode = string.Empty;
    private static string authorizeApiBaseUrl = string.Empty;

    public static string GetUserName()
    {
        return userName;
    }
    public static void SetUserName(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            userName = value;
        }
    }

    public static string GetAppCode()
    {
        return appCode;
    }

    public static void SetAppCode(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            appCode = value;
        }
    }
    public static string GetAuthorizeApiBaseUrl()
    {
        return authorizeApiBaseUrl;
    }

    public static void SetAuthorizeApiBaseUrl(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            authorizeApiBaseUrl = value;
        }
    }
}
