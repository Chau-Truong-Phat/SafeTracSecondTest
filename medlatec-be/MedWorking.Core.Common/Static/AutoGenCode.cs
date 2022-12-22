using MedWorking.Core.Common.Enums;

namespace MedWorking.Core.Common.Static;

public static class AutoGenCode
{
    public static string AutoGenerateCode(List<string> arrList, string type)
    {
        var character = type.ToCharArray();
        string genCode = string.Empty;
        bool isSuccess = false;
        if (arrList.Count > 0)
        {
            var listStr = arrList.Select(x => x.Trim(character)).ToArray();
            int[] arrNum = Array.ConvertAll(listStr, s =>
            {
                isSuccess = int.TryParse(s, out int result);
                return result;
            });
            genCode = type.ToString() + (arrNum.Max() + 1).ToString(EnumActionName.GenCode);
        }
        else
            genCode = type.ToString() + 1.ToString(EnumActionName.GenCode);
        return genCode;
    }
}
