using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class AdvisoryStaff
    {
        public Guid Id { get; set; }
        public string? AdvisoryUserId { get; set; }
        public string? AdvisoryUserName { get; set; }
        public Guid? AdvisoryOfficeId { get; set; }
    }
}
