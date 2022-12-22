namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;

public class ConfigBrowsingStepModel
{
    public Guid Id { get; set; }
    public string StepName { get; set; } = null!;
    public int ScopeApplication { get; set; }
    public long OfficeId { get; set; }
    public int ConfigType { get; set; }
    public string? Description { get; set; }
    public bool IsUnit { get; set; }
    public bool Active { get; set; }
    public string? AllOffice { get; set; }
    public List<OfficeImplement>? ListOffice { get; set; } 
    public DateTime? CreateDate { get; set; }
    public string? CreateUser { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdateUser { get; set; }
    public bool IsUseStep { get; set; }
}
