using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class PatternDocument
    {
        public Guid PatternDocId { get; set; }
        public string? PatternDocCode { get; set; }
        public string? PatternDocName { get; set; }
        public Guid? GroupDocId { get; set; }
        public string? Description { get; set; }
        public bool? PatternDocActive { get; set; }
        public string? TemplateDoc { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? DocumentValue { get; set; }
    }
}
