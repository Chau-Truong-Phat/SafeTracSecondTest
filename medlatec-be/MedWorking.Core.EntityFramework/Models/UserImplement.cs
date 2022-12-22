using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class UserImplement
    {
        public Guid Id { get; set; }
        public string? EmployeeId { get; set; }
        public long? OfficeImplementId { get; set; }
        public Guid? ConfigureBrowsingStepId { get; set; }
    }
}
