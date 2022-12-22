namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Models;

public class UserDetailByOfficeIdModel
{
    public long Id { get; set; }
    public string OfficeName { get; set; } 
    public List<UserDetail>? ListAccounts { get; set; }
}
public class UserDetail
{
    public long? Position { get; set; }
    public string? FullName { get; set; }
    public string? PositionName { get; set; }
    public string? EmployeeId { get; set; }

}
