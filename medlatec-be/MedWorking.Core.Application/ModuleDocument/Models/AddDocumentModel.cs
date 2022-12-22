namespace MedWorking.Core.Application.ModuleDocument.Models;

public class AddDocumentModel
{
    public string DocumentCode { get; set; } // Mã văn bản
    public Guid GroupDocId { get; set; } // Id nhóm văn bản
    public Guid PatternDocId { get; set; } // Id mẫu văn bản
    public string DocName { get; set; } // Tên văn bản
    public int Priority { get; set; } // Ưu tiên
    public DateTime ExpirationDate { get; set; } // hạn xử lý văn bản
    
    public List<long> ListAdvisoryUnit { get; set; } // Đơn vị tham mưu
    public List<long> ListImplementUnit { get; set; } // Đơn vị thực hiện
    public List<string> ListRelatedDocument { get; set; } // văn bản liên quan
    
    public string Explaination { get; set; } //  diễn giải
    public string Nodes { get; set; } // ghi chú
    public string Description { get; set; } // nội dung văn bản

    public string MsgComment { get; set; }  
    
    public string? CreateUser { get; set; }
    public DateTime? CreateDate { get; set; } 
}