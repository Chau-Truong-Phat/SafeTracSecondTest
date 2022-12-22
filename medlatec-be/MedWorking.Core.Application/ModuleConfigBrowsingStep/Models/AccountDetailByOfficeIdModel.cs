namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;

public class AccountDetailByOfficeIdModel
{
    public long Id { get; set; }
    public string? OfficeName { get; set; }
    public List<AccountDetail>? ListAccounts { get; set; }
}
public class AccountDetail
{
    public string UserName { get; set; }
    public string EmployeeId { get; set; }
}
