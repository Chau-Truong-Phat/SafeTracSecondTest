using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleDocument.Models;

public class DocumentModel
{
    public Guid Id { get; set; }
    public string? DocumentCode { get; set; }
    public Guid? GroupDocId { get; set; }
    public Guid? PatternDocId { get; set; }
    public string? DocName { get; set; }
    public int? Priority { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public string? Explaination { get; set; }
    public int? Status { get; set; }
    public string? CreateUser { get; set; }
    public DateTime? CreateDate { get; set; }
    public string? UpdateUser { get; set; }
    public DateTime? UpdateDate { get; set; }
    
    public List<DocumentAdvisory> ListAdvisoryUnit { get; set; } // Đơn vị tham mưu
    public List<DocumentImplementation> ListImplementUnit { get; set; } // Đơn vị thực hiện
    public List<DocumentReference> ListDocReference { get; set; } // văn bản liên quan
    public DocumentComment? MsgComment { get; set; } // ý kiến 
}