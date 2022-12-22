using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ViewApprovalGeneralDocumentProcess
    {
        public Guid? Id { get; set; }
        public Guid? GroupDocumentId { get; set; }
        public string? GroupDocName { get; set; }
        public string? PatternDocName { get; set; }
        public bool? Active { get; set; }
        public DateTime? TimeApplication { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }
        public string? PatternDocId { get; set; }
        public string? StepName { get; set; }
    }
}
