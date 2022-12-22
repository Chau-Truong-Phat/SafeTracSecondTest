using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class GroupDocument
    {
        public Guid GroupDocId { get; set; }
        public string? GroupDocCode { get; set; }
        public string? GroupDocName { get; set; }
        /// <summary>
        /// 0: Thông báo/phát hành
        /// 1: Thực hiện
        /// </summary>
        public int? DocType { get; set; }
        public string? AdvisoryUnit { get; set; }
        public string? DocNode { get; set; }
        /// <summary>
        /// trạng thái nhóm văn bản
        /// </summary>
        public bool? DocActive { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
