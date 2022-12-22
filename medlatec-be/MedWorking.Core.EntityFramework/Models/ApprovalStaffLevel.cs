using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ApprovalStaffLevel
    {
        public Guid Id { get; set; }
        public Guid? ApprovalOfficeLevelId { get; set; }
        public string? ApprovalUserId { get; set; }
        public string? ApprovalUserName { get; set; }
        public string? PositionName { get; set; }
        public int? Level { get; set; }
        public bool? IsApproved { get; set; }
    }
}
