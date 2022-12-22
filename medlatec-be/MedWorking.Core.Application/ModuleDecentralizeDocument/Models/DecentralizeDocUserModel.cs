namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Models;

public class DecentralizeDocUserModel
{
    public Guid DecentralizeDocId { get; set; }
    public string EmployeeId { get; set; } 
    public string PositionName { get; set; } 
    public string FullName { get; set; } 
    public long DecentralizeDocumentLevel { get; set; }
    public string? DecentralizeDocumentNote { get; set; }
    public string? CreateUser { get; set; }
    public DateTime? CreateDate { get; set; }
    public string? UpdateUser { get; set; }
    public DateTime? UpdateDate { get; set; }
}