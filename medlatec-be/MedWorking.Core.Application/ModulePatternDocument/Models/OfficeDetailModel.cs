namespace MedWorking.Core.Application.ModulePatternDocument.Models;

public class OfficeDetailModel
{
    public long Id { get; set; }
    public string? OfficeName { get; set; }
    public long Parent { get; set; }
    public string? Description { get; set; }
    public List<OfficeDetailModel>? ListChild { get; set; }

}

