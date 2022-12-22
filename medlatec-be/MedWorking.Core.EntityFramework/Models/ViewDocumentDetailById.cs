using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ViewDocumentDetailById
    {
        public Guid? Id { get; set; }
        public string? DocumentCode { get; set; }
        public string? DocName { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Explaination { get; set; }
        public Guid? GroupDocId { get; set; }
        public string? Notes { get; set; }
        public Guid? PatternDocId { get; set; }
        public int? Priority { get; set; }
        public int? Status { get; set; }
        public string? GroupDocName { get; set; }
        public string? PatternDocName { get; set; }
        public string? DocRefId { get; set; }
        public string? OfficeId { get; set; }
        public string? OfficeImplementId { get; set; }
        public string? Url { get; set; }
    }
}
