using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ViewConfigureBrowsingStep
    {
        public Guid? ConfigureBrowsingStepId { get; set; }
        public string? StepName { get; set; }
        public int? ScopeApplication { get; set; }
        public int? ConfigType { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsUnit { get; set; }
        public string? AllOffice { get; set; }
        public long? OfficeId { get; set; }
        public string? OfficeName { get; set; }
        public string? OfficeImplement { get; set; }
    }
}
