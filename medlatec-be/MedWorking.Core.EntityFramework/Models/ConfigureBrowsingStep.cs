using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ConfigureBrowsingStep
    {
        public Guid Id { get; set; }
        public string? StepName { get; set; }
        public int? ScopeApplication { get; set; }
        public long? OfficeId { get; set; }
        public int? ConfigType { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateUser { get; set; }
        public bool? Active { get; set; }
        public bool? IsUnit { get; set; }
        public string? AllOffice { get; set; }
    }
}
