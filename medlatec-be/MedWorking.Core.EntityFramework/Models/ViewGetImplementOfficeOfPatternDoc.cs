using System;
using System.Collections.Generic;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class ViewGetImplementOfficeOfPatternDoc
    {
        public Guid? PatternDocId { get; set; }
        public string? PatternDocCode { get; set; }
        public string? OfficeName { get; set; }
        public long? OfficeId { get; set; }
    }
}
