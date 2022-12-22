using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ApprovalStepLevel
    {
        public Guid Id { get; set; }
        public Guid? ApprovalStepLevelParentId { get; set; }
        public Guid? ApprovalGeneralDocumentProcessId { get; set; }
        public Guid? DocId { get; set; }
        public bool? Status { get; set; }
        public string? StepName { get; set; }
        public int? BrowsingStepType { get; set; }
    }
}
