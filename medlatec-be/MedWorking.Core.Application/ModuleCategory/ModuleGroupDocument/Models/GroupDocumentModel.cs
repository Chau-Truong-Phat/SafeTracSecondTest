namespace MedWorking.Core.Application.ModuleGroupDocument.Models
{
    public class GroupDocumentModel
    {
        public Guid GroupDocId { get; set; }
        public string GroupDocCode { get; set; } 
        public string GroupDocName { get; set; } 
        /// <summary>
        /// 0: Thông báo/phát hành
        /// 1: Thực hiện
        /// </summary>
        public int DocType { get; set; }
        public string? AdvisoryUnit { get; set; } 
        public string? DocNode { get; set; } 
        /// <summary>
        /// trạng thái nhóm văn bản
        /// </summary>
        public bool DocActive { get; set; }
       
    }
}
