using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class Document
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
    }
}
