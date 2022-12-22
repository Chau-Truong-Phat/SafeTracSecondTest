namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Models;

public class DecentralizeDocumentDetailModel
{
    public Guid DecentralizeDocId { get; set; }
    public string EmployeeId { get; set; } 
    public string? EmployeeName { get; set; }
    public string? EmployeePosition { get; set; }
    public long DecentralizeDocumentLevel { get; set; }
    public string? DecentralizeDocumentNote { get; set; }
    public string? Description { get; set; }
    public bool DecentralizeDocState { get; set; }
    public string? Officename { get; set; }
    public long? OfficeId { get; set; }
    public List<DecentralizeDocUserModel>? ListUsers { get; set; } 
}
