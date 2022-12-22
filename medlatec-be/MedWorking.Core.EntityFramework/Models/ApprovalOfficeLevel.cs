using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ApprovalOfficeLevel
    {
        public Guid Id { get; set; }
        public Guid? ApprovalStepLevelId { get; set; }
        public long? OfficeId { get; set; }
        public string? OfficeName { get; set; }
        public bool? Status { get; set; }
        public int? Level { get; set; }
        public int? ApprovationRequestType { get; set; }
    }
}
