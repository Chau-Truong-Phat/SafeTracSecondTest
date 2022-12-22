using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Models;

public class ApprovalGeneralDocumentProcessUnitModel
{
    public Guid Id { get; set; }
    public long OfficeId { get; set; }
    public string? OfficeName { get; set; }
    public Guid GroupDocumentId { get; set; }
    public string? PatternDocName { get; set; }
    public string? GroupDocName { get; set; }
    public DateTime TimeApplication { get; set; }
    public string? Description { get; set; }
    public bool Active { get; set; }
    public DateTime? CreateDate { get; set; }
    public string? CreateUser { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdateUser { get; set; }
    public List<PatternDocumentDetailByGroupDocument>? ListPatternDocument { get; set; }
    public List<TextBrowsingStepsUnit>? ListTextBrowsingStep { get; set; }
}
