namespace MedWorking.Core.Application.ModuleDocument.Models;

public class AdvisoryStaffModel
{
    public Guid Id { get; set; }
    public Guid? DocId { get; set; }
    public long? OfficeId { get; set; }
    public string? OfficeName { get; set; }
    public string? Comment { get; set; }
    public List<AdvisoryUser> ListAdvisoryUser { get; set; }
}
public class AdvisoryUser
{
    public string? AdvisoryUserId { get; set; }
    public string? AdvisoryUserName { get; set; }
}
