namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;

public class OfficeImplement
{
    public long OfficeImplementId { get; set; }
    public Guid ConfigStepId { get; set; }
    public long ApprovalLevel { get; set; }
    public List<string>? ListUserImplements { get; set; } 
    public string? Description { get; set; }
}
