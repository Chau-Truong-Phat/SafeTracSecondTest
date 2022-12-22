using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Models;

public class ApprovalGeneralDocumentProcessModel
{
    public Guid Id { get; set; }
    public Guid GroupDocumentId { get; set; }
    public string? GroupDocName { get; set; } 
    public string? PatternDocName { get; set; } 
    public DateTime TimeApplication { get; set; }
    public string? Description { get; set; }
    public bool Active { get; set; }
    public DateTime? CreateDate { get; set; }
    public string? CreateUser { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdateUser { get; set; }

    public List<PatternDocDetailByGroupDocGeneral>? ListPatternDocumentGeneral { get; set; }
    public List<TextBrowsingStep>? ListTextBrowsingStepGeneral { get; set; }
}
