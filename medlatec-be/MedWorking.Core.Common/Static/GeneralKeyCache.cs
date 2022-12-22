namespace MedWorking.Core.Common.Static;

public static class GeneralKeyCache
{
    public static string GetKeyCacheName(string idtinh, string key)
    {
        return idtinh + ":" + key;
    }

    public static string GetKeyCacheName(string key)
    {
        return key;
    }
}
