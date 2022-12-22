using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ImplementingAgency
    {
        public Guid Id { get; set; }
        public Guid? ConfigStepId { get; set; }
        public long? ApprovalLevel { get; set; }
        public long? OfficeImplementId { get; set; }
        public string? Description { get; set; }
    }
}
