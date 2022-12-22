namespace MedWorking.Core.Common.Static;
public static class CheckValidateDateTime
{
    public static bool IsValidDate(string value)
    {
        DateTime tempDate;
        bool validDate = DateTime.TryParse(value, out tempDate);
        if (validDate)
            return true;
        else
            return false;
    }
}
