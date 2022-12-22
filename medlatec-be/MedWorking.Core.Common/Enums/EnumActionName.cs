namespace MedWorking.Core.Common.Enums;

public static class EnumActionName
{
    public const string ADD = "ADD";
    public const string EDIT = "EDIT";
    public const string DELETE = "DELETE";
    public const string GenCode = "000000";
    public const string GroupCode = "N";
    public const string RoleCode = "VT";
    public const string DocumentTemplate = "MVB";
    public const int Value = 10;
    public const string BROWSE = "BROWSE";
}
public static class EnumCapDuyet
{
    public const int GeneralApplication = 1;
    public const int ApplyUnit = 2;
}
public static class EnumConfigType
{
    public const int Browser = 1;
    public const int Advisory = 2;
    public const int Secretary = 3;
    public const int Internal = 4;
    public const int Director = 5;
}
public static class FileType
{
    public const int Size = 268435456;
}

public static class EnumStatusDoc
{
    public const int DraftDoc = 1; // văn bản nháp
    public const int BrowseDoc = 2; // trình duyệt
    public const int ProcessedDoc = 3; // đã xử lý
}

public static class EnumBrowsingStepType
{
    public const int Approvation = 1; // Duyệt
    public const int Advisory = 2; // Tham mưu
    public const int InternalUnit = 3; // Nội bộ
    public const int Secrectary = 4; // Thư ký
    public const int Director = 5; // Giám đốc
}

public static class EnumApprovationRequestType
{
    public const int ApprovationWithoutLevel = 1; // Tất cả duyệt không quan tâm cấp
    public const int ApprovationWithLevel = 2; // Duyệt theo từng cấp
    public const int Representation = 3; // Đại diện một người duyệt
    public const int HighestLevel = 4; // Cấp cao nhất duyệt
}