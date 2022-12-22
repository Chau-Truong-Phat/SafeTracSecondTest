using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ViewSampleDocument
    {
        public Guid? PatternDocId { get; set; }
        public string? PatternDocCode { get; set; }
        public string? PatternDocName { get; set; }
        public string? Description { get; set; }
        public bool? PatternDocActive { get; set; }
        public string? TemplateDoc { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? GroupDocId { get; set; }
        public string? GroupDocName { get; set; }
        public int? DocType { get; set; }
        public string? Officename { get; set; }
    }
}
